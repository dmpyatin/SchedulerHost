using System;
using System.Collections.Generic;

namespace Timetable.Optimization.Providers
{
    public class OneSwapNeighborhoodProvider : INeighborhoodProvider
    {
        public ISolution GetBestNeighbor(ISolution solution)
        {
            ISolution result = null;

            for (int i = 1; i < solution.Count; i++)
                for (int j = i + 1; j <= solution.Count; j++)
                {
                    ISolution item = solution.Clone();
                    var t = item.Items[i];
                    item.Items[i] = item.Items[j];
                    item.Items[j] = t;

                    if (result == null || result.Cost > item.Cost) result = item;
                }

            if (result == null) 
                result = solution;
            return result;
        }

        public IEnumerable<ISolution> GetNeighbors(ISolution solution)
        {
            for (int i = 1; i < solution.Count; i++)
                for (int j = i + 1; j <= solution.Count; j++)
                {
                    ISolution item = solution.Clone();
                    var t = item.Items[i];
                    item.Items[i] = item.Items[j];
                    item.Items[j] = t;

                    yield return item;
                }
        }
    }
}
