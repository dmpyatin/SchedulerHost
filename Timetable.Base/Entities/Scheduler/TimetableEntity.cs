using System;
using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
    public class TimetableEntity : BaseEntity
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
