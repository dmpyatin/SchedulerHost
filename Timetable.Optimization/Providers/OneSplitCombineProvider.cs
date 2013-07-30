using System;
using System.Linq;

namespace Timetable.Optimization.Providers
{
    public class OneSplitCombineProvider : ICombineProvider
    {
        public ISolution Combine(ISolution solutionFirst, ISolution solutionSecond)
        {
            Random rnd = new Random();
            ISolution result = solutionFirst.Clone();

            int k = rnd.Next(solutionFirst.Count) + 1;

            for (int i = 1; i <= k; i++)
                result.Items[i] = solutionFirst.Items[i];

            for (int i = 1; i <= solutionSecond.Count; i++)
                if (!result.Items.Contains(solutionSecond.Items[i]))
                {
                    result.Items[k] = solutionSecond.Items[i];
                    k++;
                }
            return result;
        }
    }
}
