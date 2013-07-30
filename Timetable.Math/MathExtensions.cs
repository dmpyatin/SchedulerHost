namespace Timetable.Math
{
    public static class MathHelper
    {
        public static double Gaussian(this double x, double mean, double variance)
        {
            return 1.0 / System.Math.Sqrt(2.0 * System.Math.PI * variance) * System.Math.Exp(-(x - mean) * (x - mean) / (2.0 * variance));
        }

    }
}
