using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
    public class WeekType: BaseEntity
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }
}
