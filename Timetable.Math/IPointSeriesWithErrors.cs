

namespace Timetable.Math
{
    /// This is a point series where each point has an error in the y direction.
    ///
    /// @author Didier H. Besset
    /// @translator edgar.sanchez@logicstudio.net
    public interface IPointSeriesWithErrors : IPointSeries
    {
        /// @return double	weight of the point
        /// @param n int
        double WeightAt(int n);
    }
}
