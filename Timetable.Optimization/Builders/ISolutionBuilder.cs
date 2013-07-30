using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Optimization.Builders
{
    public interface ISolutionBuilder
    {
        ISolution BuildSolution();
    }  
}
