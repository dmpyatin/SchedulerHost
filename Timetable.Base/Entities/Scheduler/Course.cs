using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
	public class Course: BaseEntity
    {
        [DataMember(Name = "Name")]
		public string Name { get; set; }

        [DataMember(Name = "ScheduleInfoes")]
        public virtual ICollection<ScheduleInfo> ScheduleInfoes { get; set; }

        public Course()
        {
            ScheduleInfoes = new HashSet<ScheduleInfo>();
        }

	}
}



