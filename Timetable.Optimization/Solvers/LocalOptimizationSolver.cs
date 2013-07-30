using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Optimization.Builders;

namespace Timetable.Optimization.Solvers
{
    public class LocalOptimizationSolver : ILocalOptimizationSolver
    {
        private readonly ISolutionBuilder _solutionBuilder;

        #region Public interface

        /// <summary>
        /// Create instance of Local optimization solver
        /// </summary>
        /// <param name="solutionBuilder">ISolution builder</param>
        public LocalOptimizationSolver(ISolutionBuilder solutionBuilder)
        {
            _solutionBuilder = solutionBuilder;
        }

        /// <summary>
        /// Find a solution
        /// </summary>
        /// <param name="timeLimit">Time limit in milliseconds</param>
        /// <returns>Solution</returns>
        public ISolution Solve(TimeSpan timeLimit)
        {
            return Solve(timeLimit, null);
        }

        /// <summary>
        /// Find a solution
        /// </summary>
        /// <param name="timeLimit">Time limit in milliseconds</param>
        /// <param name="initialSolution">Initial solution</param>
        /// <returns>Solution</returns>
        public ISolution Solve(TimeSpan timeLimit, ISolution initialSolution)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            ISolution bestSolution;

            if (initialSolution != null)
            {
                bestSolution = initialSolution;
            }
            else
            {
                bestSolution = _solutionBuilder.BuildSolution();
                bestSolution.InitializeWithRandomData();
            }

            ISolution currentSolution = bestSolution;
            ISolution nextSolution;

            while (stopWatch.Elapsed < timeLimit)
            {
                do
                {
                    nextSolution = currentSolution.GetBestNeighbor();
                    if (nextSolution.Cost > currentSolution.Cost)
                        break;

                    if (bestSolution.Cost < 0 || bestSolution.Cost > nextSolution.Cost) bestSolution = nextSolution;

                    currentSolution = nextSolution;
                } while (stopWatch.Elapsed < timeLimit);

                currentSolution = _solutionBuilder.BuildSolution();
                currentSolution.InitializeWithRandomData();
            }

            stopWatch.Stop();

            return bestSolution;
        }

        #endregion
    }
}
