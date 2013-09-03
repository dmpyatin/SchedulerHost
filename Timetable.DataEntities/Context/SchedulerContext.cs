using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Timetable.Base.Entities.Scheduler;
using Timetable.Base.Interfaces.DataSources;
using Timetable.Data.Mapping;


namespace Timetable.Data.Context
{
    public sealed class SchedulerContext: BaseContext, ISchedulerDatabase
    {
        #region Tables

        public IDbSet<Department> Departments { get; set; }

        public IDbSet<Auditorium> Auditoriums { get; set; }

        public IDbSet<Faculty> Faculties { get; set; }

        public IDbSet<Building> Buildings { get; set; }

        public IDbSet<Branch> Branches { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Group> Groups { get; set; }

        public IDbSet<Lecturer> Lecturers { get; set; }

        public IDbSet<Schedule> Schedules { get; set; }

        public IDbSet<TutorialType> TutorialTypes { get; set; }

        public IDbSet<Position> Positions { get; set; }

        public IDbSet<Time> Times { get; set; }

        public IDbSet<Speciality> Specialities { get; set; }

        public IDbSet<Tutorial> Tutorials { get; set; }

        public IDbSet<ScheduleInfo> ScheduleInfoes { get; set; }

        public IDbSet<WeekType> WeekTypes { get; set; }

        public IDbSet<AuditoriumType> AuditoriumTypes { get; set; }

        public IDbSet<StudyYear> StudyYears { get; set; }

        public IDbSet<TimetableEntity> TimetableEntities { get; set; }

        #endregion
        
        public SchedulerContext()
        {
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = true;

            Initialize();
        }
        
        protected override void Initialize()
        {
            Departments = Set<Department>();
            Auditoriums = Set<Auditorium>();
            Faculties = Set<Faculty>();
            Buildings = Set<Building>();
            Courses = Set<Course>();
            Groups = Set<Group>();
            Lecturers = Set<Lecturer>();
            Schedules = Set<Schedule>();
            TutorialTypes = Set<TutorialType>();
            Positions = Set<Position>();
            Times = Set<Time>();
            Specialities = Set<Speciality>();
            Tutorials = Set<Tutorial>();
            ScheduleInfoes = Set<ScheduleInfo>();
            WeekTypes = Set<WeekType>();
            AuditoriumTypes = Set<AuditoriumType>();
            StudyYears = Set<StudyYear>();
            TimetableEntities = Set<TimetableEntity>();

            base.Initialize();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AuditoriumMapping());
            modelBuilder.Configurations.Add(new AuditoriumTypeMapping());
            modelBuilder.Configurations.Add(new BranchMapping());
            modelBuilder.Configurations.Add(new BuildingMapping());
            modelBuilder.Configurations.Add(new CourseMapping());
            modelBuilder.Configurations.Add(new DepartmentMapping());
            modelBuilder.Configurations.Add(new FacultyMapping());
            modelBuilder.Configurations.Add(new GroupMapping());
            modelBuilder.Configurations.Add(new ScheduleMapping());
            modelBuilder.Configurations.Add(new SpecialityMapping());
            modelBuilder.Configurations.Add(new TimeMapping());
            modelBuilder.Configurations.Add(new TutorialMapping());
            modelBuilder.Configurations.Add(new ScheduleInfoMapping());
            modelBuilder.Configurations.Add(new LecturersMapping());
        }

        protected override void Dispose(bool disposing)
        {
            //Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
        }

        #region ISchedulerDatabase implementation

        IQueryable<Department> ISchedulerDatabase.Departments
        {
            get { return Departments; }
        }

        IQueryable<Auditorium> ISchedulerDatabase.Auditoriums
        {
            get { return Auditoriums; }
        }

        IQueryable<Faculty> ISchedulerDatabase.Faculties
        {
            get { return Faculties; }
        }

        IQueryable<Speciality> ISchedulerDatabase.Specialities
        {
            get { return Specialities; }
        }

        IQueryable<Time> ISchedulerDatabase.Times
        {
            get { return Times; }
        }

        IQueryable<Position> ISchedulerDatabase.Positions
        {
            get { return Positions; }
        }

        IQueryable<Branch> ISchedulerDatabase.Branches
        {
            get { return Branches; }
        }

            
        IQueryable<TutorialType> ISchedulerDatabase.TutorialTypes
        {
            get { return TutorialTypes; }
        }

        IQueryable<Schedule> ISchedulerDatabase.Schedules
        {
            get { return Schedules; }
        }

        IQueryable<Lecturer> ISchedulerDatabase.Lecturers
        {
            get { return Lecturers; }
        }

        IQueryable<Group> ISchedulerDatabase.Groups
        {
            get { return Groups; }
        }

        IQueryable<Course> ISchedulerDatabase.Courses
        {
            get { return Courses; }
        }

        IQueryable<Building> ISchedulerDatabase.Buildings
        {
            get { return Buildings; }
        }

        IQueryable<Tutorial> ISchedulerDatabase.Tutorials
        {
            get { return Tutorials; }
        }

        IQueryable<ScheduleInfo> ISchedulerDatabase.ScheduleInfoes
        {
            get { return ScheduleInfoes; }
        }
        IQueryable<WeekType> ISchedulerDatabase.WeekTypes
        {
            get { return WeekTypes; }
        }

        IQueryable<AuditoriumType> ISchedulerDatabase.AuditoriumTypes
        {
            get { return AuditoriumTypes; }
        }

        IQueryable<StudyYear> ISchedulerDatabase.StudyYears
        {
            get { return StudyYears; }
        }
        IQueryable<TimetableEntity> ISchedulerDatabase.TimetableEntities
        {
            get { return TimetableEntities; }
        }

        #endregion
    }
}
