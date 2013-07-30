using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Base.Entities.Scheduler;
using Timetable.Optimization.Providers;

namespace Timetable.Optimization.Builders
{
    public class PermutationSolutionBuilder : ISolutionBuilder
    {
        private int _n;
        private ScheduleInfo[] _items;
        private IProviderContainer _providerContainer;

        public PermutationSolutionBuilder(
            int permutationLength, 
            ScheduleInfo[] items,
            IProviderContainer providerContainer)
        {
            _n = permutationLength;
            _items = items;
            _providerContainer = providerContainer;
        }

        public ISolution BuildSolution()
        {
            // Fill with random data is needed
            return new PermutationSolution(_n, _items, _providerContainer);
        }
    }
}
