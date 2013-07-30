namespace Timetable.Math
{
    /// Series for the incompleteGamma function
    public class IncompleteGammaFunctionSeries : InifiniteSeries
    {
	    /// Series parameter.
        private readonly double _alpha;
	    /// Auxiliary sum.
        private double _sum;

        /// Constructor method
        /// @param a double	series parameter
        public IncompleteGammaFunctionSeries(double a)
        {
            _alpha = a;
        }

        /// Computes the n-th term of the series and stores it in lastTerm.
        /// @param n int
        protected override void ComputeTermAt(int n)
        {
            _sum += 1;
            LastTerm *= X / _sum;
        }

        /// initializes the series and return the 0-th term.
        protected override double InitialValue()
        {
            LastTerm = 1 / _alpha;
            _sum = _alpha;
            return LastTerm;
        }
    }
}
