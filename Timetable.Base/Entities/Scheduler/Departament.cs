using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
    public class Department: BaseEntity 
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "ShortName")]
        public string ShortName { get; set; }

        [DataMember(Name = "Faculty")]
        public virtual Faculty Faculty { get; set; }

        [DataMember(Name = "FacultyId")]
        public int? FacultyId { get; set; }

        [DataMember(Name = "Lecturers")]
        public virtual ICollection<Lecturer> Lecturers { get; set; }

        public Department()
        {
            Lecturers = new HashSet<Lecturer>();
        }
    }
}
