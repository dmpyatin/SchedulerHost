using System;

namespace Timetable.Optimization.Solvers
{
    public interface ILocalOptimizationSolver
    {
        /// <summary>
        /// Find a solution
        /// </summary>
        /// <param name="timeLimit">Time limit in milliseconds</param>
        /// <returns>Solution</returns>
        ISolution Solve(TimeSpan timeLimit);

        /// <summary>
        /// Find a solution
        /// </summary>
        /// <param name="timeLimit">Time limit in milliseconds</param>
        /// <param name="initialSolution">Initial solution</param>
        /// <returns>Solution</returns>
        ISolution Solve(TimeSpan timeLimit, ISolution initialSolution);
    }
}