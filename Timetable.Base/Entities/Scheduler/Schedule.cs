using System;
using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
    public class Schedule : BaseEntity
    {
        [DataMember(Name = "Auditorium")]
        public virtual Auditorium Auditorium { get; set; }

        [DataMember(Name = "AuditoriumId")]
        public int? AuditoriumId { get; set; }

        [DataMember(Name = "DayOfWeek")]
        public int DayOfWeek { get; set; }

        [DataMember(Name = "Period")]
        public virtual Time Period { get; set; }

        [DataMember(Name = "PeriodId")]
        public int PeriodId { get; set; }

        [DataMember(Name = "ScheduleInfo")]
        public virtual ScheduleInfo ScheduleInfo { get; set; }

        [DataMember(Name = "ScheduleInfoId")]
        public int ScheduleInfoId { get; set; }

        [DataMember(Name = "WeekType")]
        public virtual WeekType WeekType { get; set; }

        [DataMember(Name = "WeekTypeId")]
        public int WeekTypeId { get; set; }

        [DataMember(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [DataMember(Name = "EndDate")]
        public DateTime EndDate { get; set; }

        [DataMember(Name = "AutoDelete")]
        public bool AutoDelete { get; set; }

        [DataMember(Name = "TimetableEntity")]
        public virtual TimetableEntity Timetable { get; set; }

        [DataMember(Name = "TimetableEntityId")]
        public int? TimetableEntityId { get; set; }

        [DataMember(Name = "SubGroup")]
        public string SubGroup { get; set; }
    }
}
