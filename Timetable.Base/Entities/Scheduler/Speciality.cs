using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
    public class Speciality: BaseEntity
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "ShortName")]
	    public string ShortName { get; set; }

        [DataMember(Name = "Code")]
	    public string Code { get; set; }

        [DataMember(Name = "Faculties")]
        public virtual ICollection<Faculty> Faculties { get; set; }

        [DataMember(Name = "ScheduleInfoes")]
        public virtual ICollection<ScheduleInfo> ScheduleInfoes { get; set; }

        [DataMember(Name = "Groups")]
        public virtual ICollection<Group> Groups { get; set; }

        public Speciality()
        {
            Faculties = new HashSet<Faculty>();
            ScheduleInfoes = new HashSet<ScheduleInfo>();
        }
    }
}
