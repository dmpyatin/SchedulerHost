using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Math.Approximation
{
    interface IApproximationBase
    {
        Func<double, double> Function { get; set; }
        double Epsilon { get; set; }
        double Result { get; }
        double IterationsNumber { get; }

        void Calculate();
    }
}
