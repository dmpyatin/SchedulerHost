using System;

namespace Timetable.Math
{
    /// <summary>
    /// This class implements additional mathematical functions
    /// and determines the parameters of the floating point representation.
    /// </summary>
    public sealed class DhbMath
    {
        /// Typical meaningful precision for numerical calculations.
        private static double _defaultNumericalPrecision = 0;

        /// Typical meaningful small number for numerical calculations.
        private static double _smallNumber = 0;

        /// Radix used by floating-point numbers.
        private static int _radix = 0;

        /// Largest positive value which, when added to 1.0, yields 0.
        private static double _machinePrecision = 0;

        /// Largest positive value which, when subtracted to 1.0, yields 0.
        private static double _negativeMachinePrecision = 0;

        /// Smallest number different from zero.
        private static double _smallestNumber = 0;

        /// Largest possible number
        private static double _largestNumber = 0;

        /// Largest argument for the exponential
        private static double _largestExponentialArgument = 0;

        /// Values used to compute human readable scales.
        private static readonly double[] Scales = { 1.25, 2, 2.5, 4, 5, 7.5, 8, 10 };
        private static readonly double[] SemiIntegerScales = { 2, 2.5, 4, 5, 7.5, 8, 10 };
        private static readonly double[] IntegerScales = { 2, 4, 5, 8, 10 };

        public static double DefaultNumericalPrecision
        {
            get
            {
                if (_defaultNumericalPrecision == 0)
                    _defaultNumericalPrecision = System.Math.Sqrt(MachinePrecision);
                return _defaultNumericalPrecision;
            }
        }

        public static double LargestExponentialArgument
        {
            get
            {
                if (_largestExponentialArgument == 0)
                    _largestExponentialArgument = System.Math.Log(LargestNumber);
                return _largestExponentialArgument;
            }
        }

        public static double LargestNumber
        {
            get
            {
                return double.MaxValue;
            }
        }

        public static double MachinePrecision
        {
            get
            {
                if (_machinePrecision == 0)
                    ComputeMachinePrecision();
                return _machinePrecision;
            }
        }

        public static double NegativeMachinePrecision
        {
            get
            {
                if (_negativeMachinePrecision == 0)
                    ComputeNegativeMachinePrecision();
                return _negativeMachinePrecision;
            }
        }

        public static int Radix
        {
            get
            {
                if (_radix == 0)
                    ComputeRadix();
                return _radix;
            }
        }

        public static double SmallestNumber
        {
            get
            {
                return double.Epsilon;
            }
        }

        private static void ComputeLargestNumber()
        {
            var floatingRadix = Radix;
            var fullMantissaNumber = 1.0d -
                                floatingRadix * NegativeMachinePrecision;
            while (!Double.IsInfinity(fullMantissaNumber))
            {
                _largestNumber = fullMantissaNumber;
                fullMantissaNumber *= floatingRadix;
            }
        }

        private static void ComputeMachinePrecision()
        {
            var floatingRadix = Radix;
            var inverseRadix = 1.0d / floatingRadix;
            _machinePrecision = 1.0d;
            var tmp = 1.0d + _machinePrecision;
            while (tmp - 1.0d != 0.0d)
            {
                _machinePrecision *= inverseRadix;
                tmp = 1.0d + _machinePrecision;
            }
        }

        private static void ComputeNegativeMachinePrecision()
        {
            double floatingRadix = Radix;
            var inverseRadix = 1.0d / floatingRadix;
            _negativeMachinePrecision = 1.0d;
            var tmp = 1.0d - _negativeMachinePrecision;
            while (tmp - 1.0d != 0.0d)
            {
                _negativeMachinePrecision *= inverseRadix;
                tmp = 1.0d - _negativeMachinePrecision;
            }
        }

        private static void ComputeRadix()
        {
            var a = 1.0d;
            var b = 1.0d;
            double tmp1, tmp2;

            do
            {
                a += a;
                tmp1 = a + 1.0d;
                tmp2 = tmp1 - a;
            } 
            while (tmp2 - 1.0d != 0.0d);

            
            while (_radix == 0)
            {
                b += b;
                tmp1 = a + b;
                _radix = (int)(tmp1 - a);
            }
        }

        private static void ComputeSmallestNumber()
        {
            double floatingRadix = Radix;
            var inverseRadix = 1.0d / floatingRadix;
            var fullMantissaNumber = 1.0d - floatingRadix * NegativeMachinePrecision;

            while (fullMantissaNumber != 0.0d)
            {
                _smallestNumber = fullMantissaNumber;
                fullMantissaNumber *= inverseRadix;
            }
        }

        /// @return boolean	true if the difference between a and b is
        /// less than the default numerical precision
        /// @param a double
        /// @param b double
        public static bool Equal(double a, double b)
        {
            return Equal(a, b, DefaultNumericalPrecision);
        }

        /// @return boolean	true if the relative difference between a and b
        /// is less than precision
        /// @param a double
        /// @param b double
        /// @param precision double
        public static bool Equal(double a, double b, double precision)
        {
            var norm = System.Math.Max(System.Math.Abs(a), System.Math.Abs(b));
            return norm < precision || System.Math.Abs(a - b) < precision * norm;
        }

        public static void Reset()
        {
            _defaultNumericalPrecision = 0;
            _smallNumber = 0;
            _radix = 0;
            _machinePrecision = 0;
            _negativeMachinePrecision = 0;
            _smallestNumber = 0;
            _largestNumber = 0;
        }

        /// <summary>
        /// This method returns the specified value rounded to
        /// the nearest integer multiple of the specified scale.
        /// </summary>
        /// <param name="value">number to be rounded</param>
        /// <param name="scale">defining the rounding scale</param>
        /// <returns>rounded value</returns>
        public static double RoundTo(double value, double scale)
        {
            return System.Math.Round(value / scale) * scale;
        }

        /// Round the specified value upward to the next scale value.
        /// @param the value to be rounded.
        /// @param a fag specified whether integer scale are used, otherwise double scale is used.
        /// @return a number rounded upward to the next scale value.
        public static double RoundToScale(double value, bool integerValued)
        {
            double[] scaleValues;
            var orderOfMagnitude = (int)System.Math.Floor(System.Math.Log(value) / System.Math.Log(10.0));
            if (integerValued)
            {
                orderOfMagnitude = System.Math.Max(1, orderOfMagnitude);
                switch (orderOfMagnitude)
                {
                    case 1:
                        scaleValues = IntegerScales;
                        break;

                    case 2:
                        scaleValues = SemiIntegerScales;
                        break;

                    default:
                        scaleValues = Scales;
                        break;
                }
            }
            else
                scaleValues = Scales;
            var exponent = System.Math.Pow(10.0, orderOfMagnitude);
            var rValue = value / exponent;

            for (var index = 0; index < scaleValues.Length; index++)
            {
                var scaleValue = scaleValues[index];
                if (rValue <= scaleValue)
                    return scaleValue*exponent;
            }
            return exponent;
        }

        public static double SmallNumber
        {
            get
            {
                if (_smallNumber == 0)
                    _smallNumber = System.Math.Sqrt(SmallestNumber);
                return _smallNumber;
            }
        }
    }
}
