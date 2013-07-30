using System;

namespace Timetable.Math
{
    /// Gamma function (Euler's integral).
    
    public sealed class GammaFunction
    {
        static readonly double Sqrt2Pi = System.Math.Sqrt(2 * System.Math.PI);
        static readonly double[] Coefficients = { 76.18009172947146,
								                 -86.50532032941677,
								                  24.01409824083091,
								                 -1.231739572450155,
								                  0.1208650973866179e-2,
								                 -0.5395239384953e-5};

        /// @return double		beta function of the arguments
        /// @param x double
        /// @param y double
        public static double Beta(double x, double y)
        {
            return System.Math.Exp(LogGamma(x) + LogGamma(y) - LogGamma(x + y));
        }

        /// @return long	factorial of n
        /// @param n long
        public static long Factorial(long n)
        {
            return n < 2 ? 1 : n * Factorial(n - 1);
        }

        /// @return double		gamma function
        /// @param x double
        public static double Gamma(double x)
        {
            return x > 1
                        ? System.Math.Exp(LeadingFactor(x)) * Series(x) * Sqrt2Pi / x
                        : (x > 0 ? Gamma(x + 1) / x
                                        : double.NaN);
        }

        /// @return double
        /// @param x double
        private static double LeadingFactor(double x)
        {
            double temp = x + 5.5;
            return System.Math.Log(temp) * (x + 0.5) - temp;
        }

        /// @return double	logarithm of the beta function of the arguments
        /// @param x double
        /// @param y double
        public static double LogBeta(double x, double y)
        {
            return LogGamma(x) + LogGamma(y) - LogGamma(x + y);
        }

        /// @return double		log of the gamma function
        /// @param x double
        public static double LogGamma(double x)
        {
            return x > 1
                        ? LeadingFactor(x) + System.Math.Log(Series(x) * Sqrt2Pi / x)
                        : (x > 0 ? LogGamma(x + 1) - System.Math.Log(x)
                                        : Double.NaN);
        }

        /// @return double		value of the series in Lanczos formula.
        /// @param x double
        private static double Series(double x)
        {
            double answer = 1.000000000190015d;
            double term = x;
            for (int i = 0; i < 6; i++)
            {
                term += 1;
                answer += Coefficients[i] / term;
            }
            return answer;
        }
    }
}
