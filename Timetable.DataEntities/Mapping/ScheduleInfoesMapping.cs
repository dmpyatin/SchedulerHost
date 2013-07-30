using System.Data.Entity.ModelConfiguration;
using Timetable.Base.Entities.Scheduler;

namespace Timetable.Data.Mapping
{
    public class ScheduleInfoMapping : EntityTypeConfiguration<ScheduleInfo>
    {
        public ScheduleInfoMapping()
        {
            HasMany(c => c.Groups).
                WithMany(p => p.ScheduleInfoes).
                Map(m =>
                {
                    m.MapLeftKey("ScheduleInfo_Id");
                    m.MapRightKey("Group_Id");
                    m.ToTable("ScheduleInfoesToGroups");
                });

            HasMany(c => c.Faculties).
                WithMany(p => p.ScheduleInfoes).
                Map(m =>
                {
                    m.MapLeftKey("ScheduleInfo_Id");
                    m.MapRightKey("Faculty_Id");
                    m.ToTable("ScheduleInfoesToFaculties");
                });

            HasMany(c => c.Specialities).
                WithMany(p => p.ScheduleInfoes).
                Map(m =>
                {
                    m.MapLeftKey("ScheduleInfo_Id");
                    m.MapRightKey("Speciality_Id");
                    m.ToTable("ScheduleInfoesToSpecialities");
                });

            HasMany(c => c.Courses).
                WithMany(p => p.ScheduleInfoes).
                Map(m =>
                {
                    m.MapLeftKey("ScheduleInfo_Id");
                    m.MapRightKey("Course_Id");
                    m.ToTable("ScheduleInfoesToCourses");
                });

            HasMany(c => c.LikeAuditoriums).
                WithMany(p => p.ScheduleInfoes).
                Map(m =>
                {
                    m.MapLeftKey("ScheduleInfo_Id");
                    m.MapRightKey("Auditorium_Id");
                    m.ToTable("ScheduleInfoesToAuditoriums");
                });

            HasRequired(x => x.Tutorial)
                .WithMany(x => x.ScheduleInfoes)
                .HasForeignKey(x => x.TutorialId);

            HasRequired(x => x.TutorialType)
                .WithMany()
                .HasForeignKey(x => x.TutorialTypeId);

            HasRequired(x => x.Lecturer)
                .WithMany(x => x.ScheduleInfoes)
                .HasForeignKey(x => x.LecturerId);

            HasRequired(x => x.StudyYear)
                .WithMany()
                .HasForeignKey(x => x.StudyYearId);

            HasRequired(x => x.Department)
                .WithMany()
                .HasForeignKey(x => x.DepartmentId);

//            Invalid column name 'Lecturer_Id'.
//Invalid column name 'Tutorial_Id'.
//Invalid column name 'Lecturer_Id'.
//Invalid column name 'Tutorial_Id'.
//Invalid column name 'Branch_Id'.
//Invalid column name 'Lecturer_Id'.
//Invalid column name 'Tutorial_Id'.

        }
    }
}
