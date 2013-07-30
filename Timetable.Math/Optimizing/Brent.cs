using System;

namespace Timetable.Math.Optimizing
{
    public class Brent
    {
        public Func<double, double> Function { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public double Epsilon { get; set; }

        /// <summary>
        /// Founded minimum
        /// </summary>
        public double ResultMin { get; protected set; }

        /// <summary>
        /// Function value in founded minimum
        /// </summary>
        public double Result { get; protected set; }

        private readonly Func<double, double, double> _m = (a, b) =>
        {
            var result = 0.0d;

            if (b > 0)
                result = System.Math.Abs(a);
            else
                result = -System.Math.Abs(a);

            return result;
        };

        /// <summary>
        /// Brent's optimization
        /// </summary>
        /// <param name="func">Function</param>
        /// <param name="left">Left limitation</param>
        /// <param name="right">Right limitation</param>
        /// <param name="eps">Accurancy</param>
        public Brent(
            Func<double, double> func, 
            double left, 
            double right, 
            double eps)
        {
            Function = func;
            Left = left;
            Right = right;
            Epsilon = eps;
        }

        public void Calculate()
        {
            var d = 0.0d;

            const double cgold = 0.3819660;
            var bx = 0.5 * (Left + Right);
            var ia = Left < Right ? Left : Right;
            var ib = Left > Right ? Left : Right;
            var v = bx;
            var w = v;
            var x = v;
            var e = 0.0d;
            var fx = Function(x);
            var fv = fx;
            var fw = fx;

            for (var iter = 1; iter <= 100; iter++)
            {
                var xm = 0.5 * (ia + ib);

                if (System.Math.Abs(x - xm) <= Epsilon * 2 - 0.5 * (ib - ia)) break;

                var u = 0.0d;
                if (System.Math.Abs(e) > Epsilon)
                {
                    var r = (x - w) * (fx - fv);
                    var q = (x - v) * (fx - fw);
                    var p = (x - v) * q - (x - w) * r;

                    q = 2 * (q - r);
                    if (q > 0)
                        p = -p;
                    q = System.Math.Abs(q);

                    var etemp = e;
                    e = d;

                    if (!(System.Math.Abs(p) >= System.Math.Abs(0.5 * q * etemp) | p <= q * (ia - x) | p >= q * (ib - x)))
                    {
                        d = p / q;
                        u = x + d;

                        if (u - ia < Epsilon * 2 | ib - u < Epsilon * 2)
                            d = _m(Epsilon, xm - x);
                    }
                    else
                    {
                        if (x >= xm)
                            e = ia - x;
                        else
                            e = ib - x;

                        d = cgold * e;
                    }
                }
                else
                {
                    if (x >= xm)
                        e = ia - x;
                    else
                        e = ib - x;

                    d = cgold * e;
                }

                if (System.Math.Abs(d) >= Epsilon)
                    u = x + d;
                else
                    u = x + _m(Epsilon, d);

                var fu = Function(u);

                if (fu <= fx)
                {
                    if (u >= x)
                        ia = x;
                    else
                        ib = x;

                    v = w;
                    fv = fw;
                    w = x;
                    fw = fx;
                    x = u;
                    fx = fu;
                }
                else
                {
                    if (u < x)
                        ia = u;
                    else
                        ib = u;

                    if (fu <= fw | w == x)
                    {
                        v = w;
                        fv = fw;
                        w = u;
                        fw = fu;
                    }
                    else
                    {
                        if (fu <= fv | v == x | v == 2)
                        {
                            v = u;
                            fv = fu;
                        }
                    }
                }
            }
            ResultMin = x;
            Result = fx;
        }
    }
}
