namespace Timetable.Optimization.Providers
{
    public interface ICombineProvider
    {
        ISolution Combine(ISolution solutionFirst, ISolution solutionSecond);
    }
}
