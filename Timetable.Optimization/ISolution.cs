using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Base.Entities;
using Timetable.Base.Entities.Scheduler;

namespace Timetable.Optimization
{
    public interface ISolution
    {
        int Count { get; set; }
        ScheduleInfo[] Items { get; set; }

        double Cost { get; }
        ISolution Clone();
        ISolution GetBestNeighbor();
        //ISolution GetRandomNeighbor();
        IEnumerable<ISolution> GetNeighbors();

        void InitializeWithRandomData();
    }
}
