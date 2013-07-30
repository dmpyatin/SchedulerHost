using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
    public class Lecturer: BaseEntity
    {
        [DataMember(Name = "Lastname")]
	    public string Lastname { get; set; }

        [DataMember(Name = "Firstname")]
	    public string Firstname { get; set; }

        [DataMember(Name = "Middlename")]
	    public string Middlename { get; set; }

        [DataMember(Name = "Contacts")]
	    public string Contacts { get; set; }

        [DataMember(Name = "Departments")]
        public virtual ICollection<Department> Departments { get; set; }

        [DataMember(Name = "Positions")]
        public virtual ICollection<Position> Positions { get; set; }
            
        [DataMember(Name = "ScheduleInfoes")]
        public virtual ICollection<ScheduleInfo> ScheduleInfoes { get; set; }

        public Lecturer()
        {
            ScheduleInfoes = new HashSet<ScheduleInfo>();
            Departments = new HashSet<Department>();
        }
    }
}
