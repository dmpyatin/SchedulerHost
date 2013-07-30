using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
    public class Group: BaseEntity 
    {
        [DataMember(Name = "Code")]
        public string Code { get; set; }

        [DataMember(Name = "Course")]
        public Course Course { get; set; }

        [DataMember(Name = "CourseId")]
        public int CourseId { get; set; }

        [DataMember(Name = "Speciality")]
        public virtual Speciality Speciality { get; set; }

        [DataMember(Name = "SpecialityId")]
        public int SpecialityId { get; set; }

        [DataMember(Name = "StudentsCount")]
        public int? StudentsCount { get; set; }

        [DataMember(Name = "Parent")]
        public Group Parent { get; set; }

        //[DataMember(Name = "ParentId")]
        //public int? ParentId { get; set; }

        [DataMember(Name = "ScheduleInfoes")]
        public virtual ICollection<ScheduleInfo> ScheduleInfoes { get; set; }
    }
}
