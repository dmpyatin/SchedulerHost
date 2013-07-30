using System;

namespace Timetable.Math.Approximation
{
    public class IterationMethod: ApproximationBase 
    {
        public double Left { get; set; }
        public double Right { get; set; }
        public double X0 { get; set; }

        private Func<double, Func<double, double>, double> g = (x, func) => 0.1 * func(x) + x; 

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="func">Function to be solved delegate</param>
        /// <param name="left">Left border of the set interval</param>
        /// <param name="right">Right border of the set interval</param>
        /// <param name="x0">Starting condition</param>
        /// <param name="epsilon">Exactness conducting of calculations</param>
        public IterationMethod(
            Func<double, double> func, 
            double left, 
            double right, 
            double x0, 
            double epsilon): base(func, epsilon)
        {
            Left = left;
            Right = right;
            X0 = x0;
        }

        public override void Calculate()
        {
            double xk;
            do
            {
                xk = g(X0, Function);
                if (System.Math.Abs(xk - X0) < Epsilon) break;
                else X0 = xk;
            }
            while (System.Math.Abs(Left - X0) > Epsilon && System.Math.Abs(Right - X0) > Epsilon);
            Result = xk;
        }
    }
}
