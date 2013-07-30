using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Base.Entities.Scheduler
{
    public class StudyYear: BaseEntity
    {
        public int StartYear { get; set; }

        public int Length { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int EndYear
        {
            get { return StartYear + Length; }
        }
    }
}
