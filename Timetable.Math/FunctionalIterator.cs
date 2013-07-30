namespace Timetable.Math
{
    /// <summary>
    /// Iterative process based on a one-variable function,
    /// having a single numerical _result.
    /// </summary>
    public abstract class FunctionalIterator : IterativeProcess
    {
        /// <summary>
        ///  Best approximation of the zero.
        /// </summary>
        protected double _result = double.NaN;

        public double Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public virtual IOneVariableFunction Function { set; get; }

        protected FunctionalIterator(IOneVariableFunction func)
        {
            this.Function = func;
        }

        public double RelativePrecision(double epsilon)
        {
            return RelativePrecision(epsilon, System.Math.Abs(_result));
        }

        
    }
}
