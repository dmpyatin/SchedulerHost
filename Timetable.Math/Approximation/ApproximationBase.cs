using System;
using System.Linq.Expressions;

namespace Timetable.Math.Approximation
{
    public abstract class ApproximationBase: IApproximationBase
    {
        public Func<double, double> Function { get; set; }
        public double Epsilon { get; set; }
        public double Result{ get; protected set; }
        public double IterationsNumber { get; protected set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="func">Function to be solved delegate.</param>
        /// <param name="eps">Exactness conducting of calculations.</param>
        protected ApproximationBase(
            Func<double, double> func, 
            double eps = 0.00001)
        {
            this.Function = func;
            this.Epsilon = eps;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="func">Function to be solved delegate.</param>
        /// <param name="eps">Exactness conducting of calculations.</param>
        protected ApproximationBase(
            Expression<Func<double, double>> func, 
            double eps = 0.00001): this(func.Compile(), eps){}

        public abstract void Calculate();
    }
}
