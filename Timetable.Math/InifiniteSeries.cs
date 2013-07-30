#region Using directives



#endregion

namespace Timetable.Math
{
    /// InifiniteSeries
    ///
    /// @author Didier H. Besset
    /// @translator edgar.sanchez@logicstudio.net
    public abstract class InifiniteSeries : IterativeProcess
    {
	    /// Best approximation of the sum.
        private double _result;
	    /// Series argument.
        protected double X;
    	/// Value of the last term.
        protected double LastTerm;

        /// Computes the n-th term of the series and stores it in lastTerm.
        /// @param n int
        protected abstract void ComputeTermAt(int n);

        public override double EvaluateIteration()
        {
            ComputeTermAt(Iterations);
            _result += LastTerm;
            return RelativePrecision(System.Math.Abs(LastTerm), System.Math.Abs(_result));
        }

        /// @return double
        public double Result
        {
            get { return _result; }
        }

        /// Set the initial value for the sum.
        public override void InitializeIterations()
        {
            _result = InitialValue();
        }

        /// @return double		the 0-th term of the series
        protected abstract double InitialValue();

        /// @param r double	the value of the series argument.
        public double Argument
        {
            set { X = value; }
        }
    }
}
