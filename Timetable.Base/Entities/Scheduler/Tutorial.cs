using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
    public class Tutorial : BaseEntity
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "ShortName")]
        public string ShortName { get; set; }

        [DataMember(Name = "Faculty")]
        public virtual Faculty Faculty { get; set; }

        [DataMember(Name = "FacultyId")]
        public int? FacultyId { get; set; }

        [DataMember(Name = "Speciality")]
        public virtual Speciality Speciality { get; set; }

        [DataMember(Name = "SpecialityId")]
        public int? SpecialityId { get; set; }

        [DataMember(Name = "ScheduleInfoes")]
        public virtual ICollection<ScheduleInfo> ScheduleInfoes { get; set; }
    }
}
