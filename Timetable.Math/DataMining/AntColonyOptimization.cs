using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Math.DataMining
{
    public class AntColonyOptimization
    {
        readonly Random _random = new Random(0);
        private const int Alpha = 3;
        private const int Beta = 2;
        private const double Rho = 0.01;
        private const double Q = 2.0;

        public int NumCities { get; private set; }
        public int NumAnts { get; set; }
        public int MaxTime { get; set; }
        public int[][] GraphDistances { get; set; }

        public int[] Path { get; private set; }
        public double Length { get; private set; }

        public AntColonyOptimization(int[][] graphDistances, int numAnts, int maxTime)
        {
            GraphDistances = graphDistances;
            NumCities = graphDistances.Length;
            NumAnts = numAnts;
            MaxTime = maxTime;
        }

        /// <summary>
        /// Calculate path
        /// </summary>
        public void Calculate()
        {
            var ants = InitAnts(NumAnts, NumCities);
            var pheromones = InitPheromones(NumCities);
            var time = 0;

            Path = BestTrail(ants, GraphDistances);
            Length = CalcLength(Path, GraphDistances);

            while (time < MaxTime)
            {
                UpdateAnts(ants, pheromones, GraphDistances);
                UpdatePheromones(pheromones, ants, GraphDistances);

                var currBestTrail = BestTrail(ants, GraphDistances);
                var currBestLength = CalcLength(currBestTrail, GraphDistances);
                if (currBestLength < Length)
                {
                    Length = currBestLength;
                    Path = currBestTrail;
                }
                ++time;
            }
        }

        double Distance(int cityX, int cityY, int[][] dists)
        {
            return dists[cityX][cityY];
        }

        int[][] InitAnts(int numAnts, int numCities) 
        {
            var ants = new int[numAnts][];
            for (var k = 0; k < numAnts; ++k)
            {
                var start = _random.Next(0, numCities);
                ants[k] = RandomTrail(start, numCities);
            }
            return ants;
        }

        double[][] InitPheromones(int numCities)
        {
            var pheromones = new double[numCities][];
            for (var i = 0; i < numCities; ++i)
                pheromones[i] = new double[numCities];

            for (var i = 0; i < pheromones.Length; ++i)
                for (var j = 0; j < pheromones[i].Length; ++j)
                    pheromones[i][j] = 0.01;

            return pheromones;
        }

        /// <summary>
        /// Helper for InitAnts
        /// </summary>
        /// <param name="start"></param>
        /// <param name="numCities"></param>
        /// <returns></returns>
        int[] RandomTrail(int start, int numCities)
        {
            var trail = new int[numCities];
            for (var i = 0; i < numCities; ++i)
                trail[i] = i;

            for (var i = 0; i < numCities; ++i)
            {
                var r = _random.Next(i, numCities);
                var tmp = trail[r]; trail[r] = trail[i]; trail[i] = tmp;
            }

            var idx = IndexOfTarget(trail, start);
            var temp = trail[0]; 
            trail[0] = trail[idx]; trail[idx] = temp;

            return trail;
        }

        /// <summary>
        /// Helper for RandomTrail
        /// </summary>
        /// <param name="trail"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        int IndexOfTarget(int[] trail, int target)
        {
            for (var i = 0; i < trail.Length; ++i)
            {
                if (trail[i] == target)
                    return i;
            }
            throw new Exception("Target not found in IndexOfTarget");
        }

        /// <summary>
        /// Total length of a trail
        /// </summary>
        /// <param name="trail"></param>
        /// <param name="dists"></param>
        /// <returns></returns>
        double CalcLength(int[] trail, int[][] dists) 
        {
            var result = 0.0;
            for (var i = 0; i < trail.Length - 1; ++i)
                result += Distance(trail[i], trail[i + 1], dists);

            return result;
        }

        /// <summary>
        /// Best trail has shortest total length
        /// </summary>
        /// <param name="ants"></param>
        /// <param name="dists"></param>
        /// <returns></returns>
        int[] BestTrail(int[][] ants, int[][] dists) 
        {
            var bestLength = CalcLength(ants[0], dists);
            var idxBestLength = 0;
            for (var k = 1; k < ants.Length; ++k)
            {
                var len = CalcLength(ants[k], dists);
                if (len < bestLength)
                {
                    bestLength = len;
                    idxBestLength = k;
                }
            }
            var numCities = ants[0].Length;
            var bestTrail = new int[numCities];
            ants[idxBestLength].CopyTo(bestTrail, 0);
            return bestTrail;
        }

        

        void UpdateAnts(int[][] ants, double[][] pheromones, int[][] dists)
        {
            var numCities = pheromones.Length;
            for (var k = 0; k < ants.Length; ++k)
            {
                var start = _random.Next(0, numCities);
                var newTrail = BuildTrail(k, start, pheromones, dists);
                ants[k] = newTrail;
            }
        }

        int[] BuildTrail(int k, int start, double[][] pheromones, int[][] dists)
        {
            var numCities = pheromones.Length;
            var trail = new int[numCities];
            var visited = new bool[numCities];
            trail[0] = start;
            visited[start] = true;
            for (var i = 0; i < numCities - 1; ++i)
            {
                var cityX = trail[i];
                var next = NextCity(k, cityX, visited, pheromones, dists);
                trail[i + 1] = next;
                visited[next] = true;
            }
            return trail;
        }

        int NextCity(int k, int cityX, bool[] visited, double[][] pheromones, int[][] dists)
        {
            var probs = MoveProbs(k, cityX, visited, pheromones, dists);
            var cumul = new double[probs.Length + 1];

            for (var i = 0; i < probs.Length; ++i)
                cumul[i + 1] = cumul[i] + probs[i];

            double p = _random.NextDouble();

            for (var i = 0; i < cumul.Length - 1; ++i)
                if (p >= cumul[i] && p < cumul[i + 1])
                    return i;

            throw new Exception("Failure to return valid city in NextCity");
        }

        double[] MoveProbs(int k, int cityX, bool[] visited, double[][] pheromones, int[][] dists)
        {
            var numCities = pheromones.Length;
            var taueta = new double[numCities];
            var sum = 0.0;

            for (var i = 0; i < taueta.Length; ++i)
            {
                if (i == cityX)
                    taueta[i] = 0.0; // Prob of moving to self is zero
                else if (visited[i] == true)
                    taueta[i] = 0.0; // Prob of moving to a visited node is zero
                else
                {
                    taueta[i] = System.Math.Pow(pheromones[cityX][i], Alpha)*
                                System.Math.Pow((1.0/Distance(cityX, i, dists)), Beta);
                    if (taueta[i] < 0.0001)
                        taueta[i] = 0.0001;
                    else if (taueta[i] > (double.MaxValue/(numCities*100)))
                        taueta[i] = double.MaxValue/(numCities*100);
                }

                sum += taueta[i];
            }

            var probs = new double[numCities];

            for (var i = 0; i < probs.Length; ++i)
                probs[i] = taueta[i] / sum;

            return probs;
        }

        void UpdatePheromones(double[][] pheromones, int[][] ants, int[][] dists)
        {
            for (var i = 0; i < pheromones.Length; ++i)
                for (var j = i + 1; j < pheromones[i].Length; ++j)
                    for (var k = 0; k < ants.Length; ++k)
                    {
                        var length = CalcLength(ants[k], dists); // length of ant k trail
                        var decrease = (1.0 - Rho) * pheromones[i][j];
                        var increase = 0.0;
                        if (EdgeInTrail(i, j, ants[k]) == true) increase = (Q / length);

                        pheromones[i][j] = decrease + increase;

                        if (pheromones[i][j] < 0.0001)
                            pheromones[i][j] = 0.0001;
                        else if (pheromones[i][j] > 100000.0)
                            pheromones[i][j] = 100000.0;

                        pheromones[j][i] = pheromones[i][j];
                    }
        }

        bool EdgeInTrail(int cityX, int cityY, int[] trail)
        {
            // are cityX and cityY adjacent to each other in trail[]?
            var lastIndex = trail.Length - 1;
            var idx = IndexOfTarget(trail, cityX);

            if (idx == 0 && trail[1] == cityY) return true;
            if (idx == 0 && trail[lastIndex] == cityY) return true;
            if (idx == 0) return false;
            if (idx == lastIndex && trail[lastIndex - 1] == cityY) return true;
            if (idx == lastIndex && trail[0] == cityY) return true;
            if (idx == lastIndex) return false;
            if (trail[idx - 1] == cityY) return true;
            return trail[idx + 1] == cityY;
        }

        
    }
}
