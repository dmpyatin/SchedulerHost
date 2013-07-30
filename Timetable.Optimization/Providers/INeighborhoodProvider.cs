using System.Collections.Generic;

namespace Timetable.Optimization.Providers
{
    public interface INeighborhoodProvider
    {
        IEnumerable<ISolution> GetNeighbors(ISolution solution);

        ISolution GetBestNeighbor(ISolution solution);
    }
}
