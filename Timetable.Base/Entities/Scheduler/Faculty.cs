using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
    public class Faculty: BaseEntity
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "ShortName")]
        public string ShortName { get; set; }

        [DataMember(Name = "ScheduleInfoes")]
        public ICollection<ScheduleInfo> ScheduleInfoes { get; set; }

        [DataMember(Name = "Specialities")]
        public ICollection<Speciality> Specialities {get; set;}

        [DataMember(Name = "Branch")]
        public virtual Branch Branch { get; set; }

        [DataMember(Name = "BranchId")]
        public int BranchId { get; set; }

        public Faculty()
        {
            Specialities = new HashSet<Speciality>();
            ScheduleInfoes = new HashSet<ScheduleInfo>();
        }
    }
}
