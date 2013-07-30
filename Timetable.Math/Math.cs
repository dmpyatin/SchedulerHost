using System;

namespace Timetable.Math
{
    public class Math
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);

        public const double MachineEpsilon = 5E-16;
        public const double MaxRealNumber = 1E300;
        public const double MinRealNumber = 1E-300;

        public static double RandomReal()
        {
            var r = 0.0d;
            lock (Random) { r = Random.NextDouble(); }
            return r;
        }

        public static int RandomInteger(int N)
        {
            var r = 0;
            lock (Random) { r = Random.Next(N); }
            return r;
        }

        public static double Sqr(double X)
        {
            return X * X;
        }

        public static double AbsComplex(Complex z)
        {
            var xabs = System.Math.Abs(z.X);
            var yabs = System.Math.Abs(z.Y);
            var w = xabs > yabs ? xabs : yabs;
            var v = xabs < yabs ? xabs : yabs;
            if (v == 0)
                return w;
            else
            {
                var t = v / w;
                return w * System.Math.Sqrt(1 + t * t);
            }
        }

        public static Complex Conj(Complex z)
        {
            return new Complex(z.X, -z.Y);
        }

        public static Complex CSqr(Complex z)
        {
            return new Complex(z.X * z.X - z.Y * z.Y, 2 * z.X * z.Y);
        }

    }
}
