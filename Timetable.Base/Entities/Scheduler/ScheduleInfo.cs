using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
    public class ScheduleInfo : BaseEntity
    {
        [DataMember(Name = "Faculties")]
        public virtual ICollection<Faculty> Faculties { get; set; }

        [DataMember(Name = "Courses")]
        public virtual ICollection<Course> Courses { get; set; }

        [DataMember(Name = "Specialities")]
        public virtual ICollection<Speciality> Specialities { get; set; }

        [DataMember(Name = "Groups")]
        public virtual ICollection<Group> Groups { get; set; }

        [DataMember(Name = "LikeAuditoriums")]
        public virtual ICollection<Auditorium> LikeAuditoriums { get; set; }

        [DataMember(Name = "Schedules")]
        public virtual ICollection<Schedule> Schedules { get; set; }

        [DataMember(Name = "Lecturer")]
        public virtual Lecturer Lecturer { get; set; }

        [DataMember(Name = "LecturerId")]
        public int LecturerId { get; set; }

        [DataMember(Name = "TutorialType")]
        public virtual TutorialType TutorialType { get; set; }

        [DataMember(Name = "TutorialTypeId")]
        public int TutorialTypeId { get; set; }

        [DataMember(Name = "Department")]
        public virtual Department Department { get; set; }

        [DataMember(Name = "DepartmentId")]
        public int? DepartmentId { get; set; }

        [DataMember(Name = "SubgroupCount")]
        public int SubgroupCount { get; set; }

        [DataMember(Name = "HoursPerWeek")]
        public int HoursPerWeek { get; set; }

        [DataMember(Name = "Tutorial")]
        public virtual Tutorial Tutorial { get; set; }

        [DataMember(Name = "TutorialId")]
        public int TutorialId { get; set; }

        [DataMember(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [DataMember(Name = "EndDate")]
        public DateTime EndDate { get; set; }

        [DataMember(Name = "StudyYear")]
        public virtual StudyYear StudyYear { get; set; }

        [DataMember(Name = "StudyYearId")]
        public int StudyYearId { get; set; }

        [DataMember(Name = "Semester")]
        public int Semester { get; set; }

        public ScheduleInfo()
        {
            Groups = new HashSet<Group>();
            Faculties = new HashSet<Faculty>();
            Courses = new HashSet<Course>();
            Specialities = new HashSet<Speciality>();
            LikeAuditoriums = new HashSet<Auditorium>();
            Schedules = new HashSet<Schedule>();
        }
    }
}
