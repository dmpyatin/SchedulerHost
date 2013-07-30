using System;
namespace Timetable.Optimization.Providers
{
    public interface IProviderContainer
    {
        ICombineProvider CombineProvider { get; }
        ICostProvider CostProvider { get; }
        INeighborhoodProvider NeighborhoodProvider { get; }
    }
}
