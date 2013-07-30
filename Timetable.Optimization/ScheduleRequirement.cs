using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Base.Entities;
using Timetable.Base.Entities.Scheduler;

namespace Timetable.Optimization
{
    public class ScheduleRequirement
    {
        public ScheduleInfo Info { get; set; }
        public double Cost { get; set; }
    }
}
