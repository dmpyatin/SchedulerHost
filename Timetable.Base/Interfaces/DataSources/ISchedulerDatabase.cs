using System.Linq;
using Timetable.Base.Entities.Scheduler;

namespace Timetable.Base.Interfaces.DataSources
{
    public interface ISchedulerDatabase: IDatabase
    {
        IQueryable<Department> Departments { get; }

        IQueryable<Auditorium> Auditoriums { get; }

        IQueryable<Faculty> Faculties { get; }

        IQueryable<Speciality> Specialities { get; }

        IQueryable<Building> Buildings { get; }

        IQueryable<Branch> Branches { get; }

        IQueryable<Course> Courses { get; }

        IQueryable<Group> Groups { get; }

        IQueryable<Lecturer> Lecturers { get; }

        IQueryable<Schedule> Schedules { get; }

        IQueryable<TutorialType> TutorialTypes { get; }

        IQueryable<Position> Positions { get; }

        IQueryable<Time> Times { get; }

        IQueryable<Tutorial> Tutorials { get; }

        IQueryable<WeekType> WeekTypes { get; }

        IQueryable<ScheduleInfo> ScheduleInfoes { get; }

        IQueryable<AuditoriumType> AuditoriumTypes { get; }

        IQueryable<StudyYear> StudyYears { get; }

        IQueryable<TimetableEntity> TimetableEntities { get; }
    }
}
