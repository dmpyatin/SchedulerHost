namespace Timetable.Math
{
    public interface ICurve : IPointSeries
    {
        void AddPoint(double x, double y);
        void RemovePointAt(int index);
    }
}
