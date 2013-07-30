using System;

namespace Timetable.Math.Approximation
{
    public class Bisection : ApproximationBase
    {
        public double Left { get; set; }
        public double Right { get; set; }

        /// <param name="func">Function</param>
        /// <param name="left">Left border of the set interval.</param>
        /// <param name="right">Right border of the set interval.</param>
        /// <param name="eps">Accurancy</param>
        public Bisection(
            Func<double, double> func, 
            double left, 
            double right, 
            double eps): base(func, eps)
        {
            Left = left;
            Right = right;
        }

        public override void Calculate()
        {
            IterationsNumber = 0;

            var blnError = false;
            double c;
            do
            {
                this.IterationsNumber++;
                c = (Left + Right) / 2;
                if (Function(Left) * Function(c) < 0)
                    Right = c;
                else
                    Left = c;
                if (Function(c) == 0)
                {
                    blnError = (!(Function(c - Epsilon / 2) * Function(c + Epsilon / 2) < 0));
                    break;
                }
            }
            while ((Function(c)) > Epsilon || (Right - Left) > Epsilon);
            if (blnError == false)
            {
                this.Result = c;
            }
        }
    }
}
