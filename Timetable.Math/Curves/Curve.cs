using System.Collections.Generic;

namespace Timetable.Math.Curves
{
    /// A Curve is a series of points. A point is implemented as an array
    /// of two doubles. The points are stored in a vector so that points
    /// can be added or removed.
    public class Curve : ICurve
    {
        /// Vector containing the points.
        protected List<double[]> Points;

        /// Constructor method. Initializes the vector.
        public Curve()
        {
            Points = new List<double[]>();
        }

        /// Adds a point to the curve defined by its 2-dimensional coordinates.
        /// @param x double x-coordinate of the point
        /// @param y double y-coordinate of the point
        public void AddPoint(double x, double y)
        {
            Points.Add(new [] { x, y });
        }

        /// Removes the point at the specified index.
        /// @param int index of the point to remove
        public void RemovePointAt(int index)
        {
            Points.RemoveAt(index);
        }

        /// @return int the number of points in the curve.
        public int Count
        {
            get { return Points.Count; }
        }

        /// @return double the x coordinate of the point at the given index.
        /// @param int index the index of the point.
        public double XValueAt(int index)
        {
            return Points[index][0];
        }

        /// @return double the y coordinate of the point at the given index.
        /// @param int index the index of the point.
        public double YValueAt(int index)
        {
            return Points[index][1];
        }
    }
}
