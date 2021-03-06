﻿using System;

namespace Timetable.Math.Approximation
{
    public class Newton: ApproximationBase
    {
        public Func<double, double> Df { get; set; }
        public double X0 { get; set; }

        const double m = 2.41064f;
        const double M = 20.0828f;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="func">Function to be solved delegate</param>
        /// <param name="df"> </param>
        /// <param name="x0">Starting condition</param>
        /// <param name="epsilon">Exactness conducting of calculations</param>
        public Newton(
            Func<double, double> func, 
            Func<double, double> df, 
            double x0, 
            double epsilon): base(func, epsilon)
        {
            Df = df;
            X0 = x0;
        }


        public override void Calculate()
        {
            IterationsNumber = 0;
            var xk = X0;
            do
            {
                IterationsNumber++;
                X0 = xk;
                xk = X0 - (Function(X0) / Df(X0));
            }
            while (System.Math.Abs(xk - X0) > System.Math.Sqrt(System.Math.Abs(2f * Epsilon * m / M)));
            Result = X0;
        }
    }
}
