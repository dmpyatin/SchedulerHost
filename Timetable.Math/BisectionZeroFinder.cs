using System;

namespace Timetable.Math
{
    /// <summary>
    ///  Zero finding by bisection.
    /// </summary>
    public class BisectionZeroFinder : FunctionalIterator
    {
	    /// Value at which the function's value is negative.
        private double _xNeg;

	    /// Value at which the function's value is positive.
        private double _xPos;

        public BisectionZeroFinder(IOneVariableFunction func) : base(func){}

        /// @param func DhbInterfaces.OneVariableFunction
        /// @param x1 location at which the function yields a negative value
        /// @param x2 location at which the function yields a positive value
        public BisectionZeroFinder(IOneVariableFunction func, double x1, double x2): this(func)
        {
            this.NegativeX = x1;
            this.PositiveX = x2;
        }

        /// @return double
        public override double EvaluateIteration()
        {
            _result = (_xPos + _xNeg) * 0.5;

            if (Function.Value(_result) > 0)
                _xPos = _result;
            else
                _xNeg = _result;

            return RelativePrecision(System.Math.Abs(_xPos - _xNeg));
        }

        /// @param x double
        /// @exception ArgumentException if the function's value is not negative
        public double NegativeX
        {
            set
            {
                if (Function.Value(value) > 0)
                    throw new ArgumentException(
                        String.Format("f({0}) is positive instead of negative", value));

                _xNeg = value;
            }
        }

        /// @param x double
        /// @exception ArgumentException if the function's value is not positive
        public double PositiveX
        {
            set
            {
                if (Function.Value(value) < 0)
                    throw new ArgumentException(
                        String.Format("f({0}) is negative instead of positive", value));

                _xPos = value;
            }
        }
    }
}
