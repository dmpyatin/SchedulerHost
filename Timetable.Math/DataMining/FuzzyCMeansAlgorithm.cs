using System;
using System.Collections.Generic;

namespace Timetable.Math.DataMining
{
    public sealed class FuzzyCMeansAlgorithm
    {
        /// <summary>
        /// Array containing all points used by the algorithm
        /// </summary>
        private readonly List<ClusterPoint> _points;

        /// <summary>
        /// Array containing all clusters handled by the algorithm
        /// </summary>
        private readonly List<ClusterPoint> _clusters;

        /// <summary>
        /// Gets or sets membership matrix
        /// </summary>
        public double[,] U;

        /// <summary>
        /// Gets or sets the current fuzzyness factor
        /// </summary>
        private readonly double _fuzzyness;

        /// <summary>
        /// Algorithm precision
        /// </summary>
        private readonly double _eps = System.Math.Pow(10, -5);

        /// <summary>
        /// Gets or sets objective function
        /// </summary>
        private double _j { get; set; }

        /// <summary>
        /// Gets or sets log message
        /// </summary>
        public string Log { get; set; }

        /// <summary>
        /// Initialize the algorithm with points and initial clusters
        /// </summary>
        /// <param name="points">Points</param>
        /// <param name="clusters">Clusters</param>
        /// <param name="fuzzy">The fuzzyness factor to be used</param>
        public FuzzyCMeansAlgorithm(List<ClusterPoint> points, List<ClusterPoint> clusters, float fuzzy)
        {
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }

            if (clusters == null)
            {
                throw new ArgumentNullException("clusters");
            }

            this._points = points;
            this._clusters = clusters;

            U = new double[this._points.Count, this._clusters.Count];

            this._fuzzyness = fuzzy;

            // Iterate through all points to create initial U matrix
            for (var i = 0; i < this._points.Count; i++)
            {
                var p = this._points[i];
                var sum = 0.0;

                for (var j = 0; j < this._clusters.Count; j++)
                {
                    var c = this._clusters[j];
                    var diff = System.Math.Sqrt(System.Math.Pow(p.X - c.X, 2.0) + System.Math.Pow(p.Y - c.Y, 2.0));
                    U[i, j] = (diff == 0) ? _eps : diff;
                    sum += U[i, j];
                }

                var sum2 = 0.0d;
                for (var j = 0; j < this._clusters.Count; j++)
                {
                    U[i, j] = 1.0 / System.Math.Pow(U[i, j] / sum, 2.0 / (_fuzzyness - 1.0));
                    sum2 += U[i, j];
                }

                for (var j = 0; j < this._clusters.Count; j++)
                    U[i, j] = U[i, j] / sum2;
            }

            this.RecalculateClusterIndexes();
        }

        /// <summary>
        /// Recalculates cluster indexes
        /// </summary>
        private void RecalculateClusterIndexes() 
        {
            for (var i = 0; i < this._points.Count; i++)
            {
                var max = -1.0;
                var p = this._points[i];

                for (var j = 0; j < this._clusters.Count; j++)
                {
                    if (max < U[i, j])
                    {
                        max = U[i, j];
                        p.ClusterIndex = (max == 0.5) ? 0.5 : j;
                    }
                }
            }
        }

        /// <summary>
        /// Perform one step of the algorithm
        /// </summary>
        public void Step()
        {
            for (var c = 0; c < _clusters.Count; c++)
            {
                for (var h = 0; h < _points.Count; h++)
                {
                    var top = CalculateEulerDistance(_points[h], _clusters[c]);
                    if (top < 1.0) top = _eps;

                    // Bottom is the sum of distances from this data point to all clusters.
                    var sumTerms = 0.0;
                    for (var ck = 0; ck < _clusters.Count; ck++)
                    {
                        var thisDistance = CalculateEulerDistance(_points[h], _clusters[ck]);
                        if (thisDistance < 1.0) 
                            thisDistance = _eps;
                        sumTerms += System.Math.Pow(top / thisDistance, 2.0 / (this._fuzzyness - 1.0));
                    }
                    
                    // Then the MF can be calculated as...
                    U[h, c] = (double)(1.0 / sumTerms);                    
                }
            }

            this.RecalculateClusterIndexes();
        }

        /// <summary>
        /// Calculates Euler's distance between point and centroid
        /// </summary>
        /// <param name="p">Point</param>
        /// <param name="c">Centroid</param>
        /// <returns>Calculated distance</returns>
        private double CalculateEulerDistance(ClusterPoint p, ClusterPoint c) 
        {
            return System.Math.Sqrt(System.Math.Pow(p.X - c.X, 2) + System.Math.Pow(p.Y - c.Y, 2));
        }

        /// <summary>
        /// Calculate the objective function
        /// </summary>
        /// <returns>The objective function as double value</returns>
        private double CalculateObjectiveFunction()
        {
            double jk = 0;

            for (var i = 0; i < this._points.Count;i++)
                for (var j = 0; j < this._clusters.Count; j++)
                    jk += System.Math.Pow(U[i, j], this._fuzzyness) * System.Math.Pow(this.CalculateEulerDistance(_points[i], _clusters[j]), 2);

            return jk;
        }

        /// <summary>
        /// Calculates the centroids of the clusters 
        /// </summary>
        private void CalculateClusterCenters()
        {
            for (var j = 0; j < this._clusters.Count; j++)
            {
                var c = this._clusters[j];
                var uX = 0.0;
                var uY = 0.0;
                var l = 0.0;

                for (var i = 0; i < this._points.Count; i++)
                {
                    var uu = System.Math.Pow(U[i, j], this._fuzzyness);
                    uX += uu * c.X;
                    uY += uu * c.Y;
                    l += uu;
                }

                c.X = ((int)(uX / l));
                c.Y = ((int)(uY / l));

                this.Log += string.Format("Cluster Centroid: ({0}; {1})" + System.Environment.NewLine, c.X, c.Y);
            }
        }

        /// <summary>
        /// Perform a complete run of the algorithm until the desired accuracy is achieved.
        /// For demonstration issues, the maximum Iteration counter is set to 20.
        /// </summary>
        /// <param name="accuracy">Algorithm accuracy</param>
        /// <returns>The number of steps the algorithm needed to complete</returns>
        public int Run(double accuracy)
        {
            var i = 0;
            const int maxIterations = 20;
            do
            {
                i++;
                this._j = this.CalculateObjectiveFunction();
                this.CalculateClusterCenters();
                this.Step();
                var jnew = this.CalculateObjectiveFunction();
                if (System.Math.Abs(this._j - jnew) < accuracy) break;  
            }
            while (maxIterations > i);

            return i;
        }
    }

}
