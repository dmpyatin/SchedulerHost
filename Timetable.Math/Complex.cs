namespace Timetable.Math
{
    /// <summary>
    /// Class defining a complex number with double precision.
    /// </summary>
    public struct Complex
    {
        public double X;

        public double Y;

        public bool Equals(Complex other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Complex && Equals((Complex) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode()*397) ^ Y.GetHashCode();
            }
        }

        public Complex(double x)
        {
            X = x;
            Y = 0;
        }

        public Complex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator Complex(double _x)
        {
            return new Complex(_x);
        }

        public static bool operator ==(Complex lhs, Complex rhs)
        {
            return (lhs.X == rhs.X) & (lhs.Y == rhs.Y);
        }

        public static bool operator !=(Complex lhs, Complex rhs)
        {
            return (lhs.X != rhs.X) | (lhs.Y != rhs.Y);
        }

        public static Complex operator +(Complex lhs)
        {
            return lhs;
        }

        public static Complex operator -(Complex lhs)
        {
            return new Complex(-lhs.X, -lhs.Y);
        }

        public static Complex operator +(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        public static Complex operator -(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public static Complex operator *(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.X * rhs.X - lhs.Y * rhs.Y, lhs.X * rhs.Y + lhs.Y * rhs.X);
        }

        public static Complex operator /(Complex lhs, Complex rhs)
        {
            Complex result;
            double e;
            double f;
            if (System.Math.Abs(rhs.Y) < System.Math.Abs(rhs.X))
            {
                e = rhs.Y / rhs.X;
                f = rhs.X + rhs.Y * e;
                result.X = (lhs.X + lhs.Y * e) / f;
                result.Y = (lhs.Y - lhs.X * e) / f;
            }
            else
            {
                e = rhs.X / rhs.Y;
                f = rhs.Y + rhs.X * e;
                result.X = (lhs.Y + lhs.X * e) / f;
                result.Y = (-lhs.X + lhs.Y * e) / f;
            }
            return result;
        }
    }
}