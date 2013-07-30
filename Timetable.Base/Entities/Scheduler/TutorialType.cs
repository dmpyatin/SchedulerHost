using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
    public class TutorialType : BaseEntity
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        //[DataMember(Name = "Type")]
        //public Types Type { get { return (Types)Id; } }

        [DataMember(Name = "AuditoriumApplicabilities")]
        public virtual ICollection<Auditorium> AuditoriumApplicabilities { get; set; }
    }

    public enum Types
    {
        Lecture = 1,

        Practice = 2,

        Lab = 3
    }
}
