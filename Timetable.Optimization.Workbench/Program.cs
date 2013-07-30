using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Data.Context;
using Timetable.Optimization.Builders;
using Timetable.Optimization.Providers;
using Timetable.Optimization.Solvers;

namespace Timetable.Optimization.Workbench
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new SchedulerContext();

            var neigborhoodProvider = new OneSwapNeighborhoodProvider();
            var combineProvider = new OneSplitCombineProvider();
            var costProvider = new CostProvider(database);

            var providerContainer = new ProviderContainer(costProvider, neigborhoodProvider, combineProvider);

            //var permutationSolutionBuilder = new PermutationSolutionBuilder(
            //var localOptimizationSolver = new LocalOptimizationSolver(permutationSolutionBuilder);
        }
    }
}
