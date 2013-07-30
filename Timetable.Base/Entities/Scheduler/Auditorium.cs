using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
    public class Auditorium : BaseEntity
    {
        [DataMember(Name = "Number")]
        public string Number { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Capacity")]
        public int? Capacity { get; set; }

        [DataMember(Name = "Info")]
        public string Info { get; set; }

        [DataMember(Name = "TutorialApplicabilities")]
        public ICollection<TutorialType> TutorialApplicabilities { get; set; }

        [DataMember(Name = "ScheduleInfoes")]
        public ICollection<ScheduleInfo> ScheduleInfoes { get; set; }

        [DataMember(Name = "Building")]
        public virtual Building Building { get; set; }

        [DataMember(Name = "BuildingId")]
        public int BuildingId { get; set; }

        [DataMember(Name = "AuditoriumType")]
        public virtual AuditoriumType AuditoriumType { get; set; }

        [DataMember(Name = "AuditoriumTypIde")]
        public int AuditoriumTypeId { get; set; }

        public Auditorium()
        {
            TutorialApplicabilities = new HashSet<TutorialType>();

            ScheduleInfoes = new HashSet<ScheduleInfo>();
        }
    }
}
