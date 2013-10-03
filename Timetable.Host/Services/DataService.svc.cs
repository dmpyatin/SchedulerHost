using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using Timetable.Base.Entities.Scheduler;
using Timetable.Base.Interfaces.DataSources;
using Timetable.Host.Interfaces;
using Group = Timetable.Base.Entities.Scheduler.Group;

namespace Timetable.Host.Services
{
    public class DataService : BaseService<ISchedulerDatabase>, IDataService
    {
        #region Operations implementation

        public IQueryable<TimetableEntity> GetTimetableEntities()
        {
            return Database.TimetableEntities
                .Where(x => x.IsActual);
        }

        public bool ValidateSchedule(Schedule schedule)
        {
            var schedulesCount = 0;
            var schedules = Database.Schedules.Where(
                    x => x.IsActual &&
                    x.AuditoriumId == schedule.AuditoriumId &&
                    x.PeriodId == schedule.PeriodId &&
                    x.DayOfWeek == schedule.DayOfWeek &&
                   (x.StartDate >= schedule.StartDate && x.StartDate <= schedule.EndDate ||
                    x.EndDate >= schedule.StartDate && x.EndDate <= schedule.EndDate)
                    );


            if (schedule.WeekTypeId == 1)
                schedulesCount = schedules.Count();
            if (schedule.WeekTypeId == 2)
                schedulesCount = schedules.Where(x => x.WeekTypeId == 1 || x.WeekTypeId == 2).Count();
            if (schedule.WeekTypeId == 3)
                schedulesCount = schedules.Where(x => x.WeekTypeId == 1 || x.WeekTypeId == 3).Count();

            if (schedulesCount == 0)
                return true;
        
            return false;
        }

        public IQueryable<Branch> GetBranches()
        {
            return Database.Branches
                .Where(x => x.IsActual);
        }

        public IQueryable<Auditorium> GetAuditoriums(Building building, AuditoriumType auditoriumType)
        {
            if (auditoriumType != null)
            {
                // TODO: Need tutorial type reference
                return Database.Auditoriums
                    .Where(x => x.Building.Id.Equals(building.Id))
                    .Where(x => x.AuditoriumType.Id == auditoriumType.Id)
                    .Include(x => x.Building);
            }
            else
            {
                return Database.Auditoriums
                    .Where(x => x.Building.Id.Equals(building.Id))
                    .Where(x => x.AuditoriumType == null)
                    .Include(x => x.Building);
            }

        }

        public IQueryable<Auditorium> GetFreeAuditoriums(
            Building building,
            int dayOfWeek,
            WeekType weekType,
            Time time,
            TutorialType tutorialType,
            AuditoriumType auditoriumType,
            int capacity,
            DateTime startDate,
            DateTime endDate)
        {
           
            IQueryable<Auditorium> freeAuditoriums;
            IQueryable<Auditorium> scheduledAuditoriums;

            if (weekType.Id == 1)
            {
                scheduledAuditoriums = Database.Schedules
                     .Where(x => x.IsActual)
                     .Where(x => x.StartDate <= endDate && x.EndDate >= startDate) 
                     .Where(x => x.Period.Id == time.Id)
                     .Where(x => x.DayOfWeek == dayOfWeek)
                     .Where(x => (x.WeekType.Id == weekType.Id || x.WeekType.Id == 2 || x.WeekType.Id == 3))
                     .Select(x => x.Auditorium);
            }
            else
            {
                scheduledAuditoriums = Database.Schedules
                     .Where(x => x.IsActual)
                     .Where(x => x.StartDate <= endDate && x.EndDate >= startDate) 
                     .Where(x => x.Period.Id == time.Id)
                     .Where(x => x.DayOfWeek == dayOfWeek)
                     .Where(x => (x.WeekType.Id == weekType.Id || x.WeekType.Id == 1))
                     .Select(x => x.Auditorium);
            }



            if (tutorialType == null)
            {
                freeAuditoriums = Database.Auditoriums
                    .Where(x => x.Building.Id == building.Id)
                    .Where(x => x.Capacity >= capacity)
                    .Where(x => x.AuditoriumType.Id == auditoriumType.Id)
                    .Where(x => !scheduledAuditoriums.Any(y => y.Id == x.Id));
            }
            else
            {
                freeAuditoriums = Database.Auditoriums
                    .Where(x => x.Building.Id == building.Id)
                    .Where(x => x.Capacity >= capacity)
                    .Where(x => x.AuditoriumType.Id == auditoriumType.Id)
                    .Where(x => !scheduledAuditoriums.Any(y => y.Id == x.Id))
                    .Where(x => x.TutorialApplicabilities.Any(y => y.Id == tutorialType.Id));

            }

            return freeAuditoriums;
        }

        public IQueryable<Building> GetBuildings()
        {
            return Database.Buildings;
        }

        public IQueryable<Course> GetCources()
        {
            return Database.Courses
                .Where(x => x.IsActual);
        }

        public IQueryable<Department> GetDeparmtents()
        {
            return Database.Departments;
        }


        public IQueryable<Faculty> GetFaculties(Branch branch = null)
        {
            if (branch == null)
                return Database.Faculties
                    .Where(x => x.IsActual)
                    .Where(x => x.Branch == null);

            return Database.Faculties
                .Where(x => x.IsActual)
                .Where(x => x.BranchId == branch.Id);
        }

        #region Groups

        public Group GetGroupById(int groupId)
        {
            return Database.Groups
                .FirstOrDefault(x => x.Id == groupId);
        }

        public IQueryable<Group> GetGroupsByCode(string code, int count)
        {
            return Database.Groups.Where(x => x.Code.Contains(code)).Take(count);
        }

        public IQueryable<Group> GetsSubGroupsByGroupId(int groupId)
        {
            return Database.Groups
                .Where(x => x.Parent.Id.Equals(groupId));
        }

        public IQueryable<Group> GetGroups(Faculty faculty, Course course)
        {
            return Database.Groups
                .Where(x => x.IsActual)
                .Where(x => x.Course.Id.Equals(course.Id))
                .Where(x => x.Speciality.Faculties
                    .Any(y => y.Id.Equals(faculty.Id)));
        }

        public IQueryable<Group> GetGroups(Course course, Speciality speciality)
        {
            return Database.Groups
                .Where(x => x.IsActual)
                .Where(x => x.Speciality.Id.Equals(speciality.Id))
                .Where(x => x.Course.Id.Equals(course.Id));
        }

        #endregion

        #region Lecturers

        public IQueryable<Lecturer> GetLecturersByDeparmentId(Department department)
        {
            return Database.Lecturers
                .Where(x => x.Departments
                    .Any(y => y.Id.Equals(department.Id)));
        }

        public IQueryable<Lecturer> GetLecturersByTutorialId(Tutorial tutorial)
        {
            return Database.ScheduleInfoes
                .Where(x => x.Tutorial.Id.Equals(tutorial.Id))
                .Select(x => x.Lecturer);
        }

        public IQueryable<Lecturer> GetLecturersByTutorialIdAndTutorialTypeId(
            Tutorial tutorial,
            TutorialType tutorialType)
        {
            return Database.ScheduleInfoes
                .Where(x => x.Tutorial.Id.Equals(tutorial.Id))
                .Where(x => x.TutorialType.Id.Equals(tutorialType.Id))
                .Select(x => x.Lecturer);
        }


        public Lecturer GetLecturerByFirstMiddleLastname(string arg)
        {
            return GetLecturersByFirstMiddleLastname(arg)
                .FirstOrDefault();
        }

        public IQueryable<Lecturer> GetLecturersByFirstMiddleLastname(string arg)
        {
            var match = Regex.Match(arg, "[а-яА-Я]*");

            var result = new List<Lecturer>();

            while (match.Success)
            {
                if (!string.IsNullOrEmpty(match.Value))
                {
                    var query = Database.Lecturers
                        .Where(x => x.Lastname.Contains(match.Value)
                                    || x.Middlename.Contains(match.Value)
                                    || x.Firstname.Contains(match.Value))
                        .Include(x => x.Departments);

                    result.AddRange(query);
                }

                match = match.NextMatch();
            }

            return result.AsQueryable();
        }

        #endregion

        #region ScheduleInfoes

        public ScheduleInfo GetScheduleInfoById(int id)
        {
            return GetScheduleInfoes()
                .FirstOrDefault(scheduleInfo => scheduleInfo.Id == id);
        }

        public IQueryable<ScheduleInfo> GetScheduleInfoesForCourse(
            Faculty faculty,
            Course course,
            StudyYear studyYear,
            int semester)
        {
            return GetScheduleInfoes()
                .Where(x => x.StudyYear.Id == studyYear.Id)
                .Where(x => x.Semester == semester)
                .Where(x => x.Faculties.Any(f => f.Id.Equals(faculty.Id)))
                .Where(x => x.Courses.Any(c => c.Id.Equals(course.Id)));
        }

        public IQueryable<ScheduleInfo> GetScheduleInfoesForSpeciality(
            Faculty faculty,
            Course course,
            Speciality speciality,
            StudyYear studyYear,
            int semester)
        {
            return GetScheduleInfoesForCourse(faculty, course, studyYear, semester)
                .Where(x => x.Specialities.Any(y => y.Id.Equals(speciality.Id)));
        }

        public IQueryable<ScheduleInfo> GetScheduleInfoesForGroup(
            Faculty faculty,
            Course course,
            Group group,
            TutorialType tutorialtype,
            StudyYear studyYear,
            int semester)
        {
            return GetScheduleInfoesForCourse(faculty, course, studyYear, semester)
                .Where(x => x.Groups.Any(y => y.Id.Equals(group.Id)))
                .Where(x => x.TutorialType.Id.Equals(tutorialtype.Id));
        }



        public IQueryable<ScheduleInfo> GetScheduleInfoesForDepartment(
            Department department,
            StudyYear studyYear,
            int semester)
        {
            return GetScheduleInfoes()
                .Where(x => x.StudyYear.Id == studyYear.Id)
                .Where(x => x.Semester == semester)
                .Where(x => x.Department.Id.Equals(department.Id));
        }

        public IQueryable<ScheduleInfo> GetUnscheduledInfoes(
            Faculty faculty,
            Course course,
            Speciality speciality,
            Group group)
        {
            var test = GetScheduleInfoes()
                .Where(x => x.Schedules.Count == 0)
                .Where(x => x.Faculties.Any(y => y.Id == faculty.Id))
                .Where(x => x.Courses.Any(y => y.Id == course.Id))
                .Where(x => x.Groups.Any(y => y.Id == group.Id));

            return test.AsQueryable();
        }

        private IQueryable<ScheduleInfo> GetScheduleInfoes()
        {
            return Database.ScheduleInfoes
                .Include(x => x.Lecturer)
                .Include(x => x.Tutorial)
                .Include(x => x.TutorialType)
                .Include(x => x.Courses)
                .Include(x => x.Groups)
                .Include(x => x.Faculties)
                .Include(x => x.Specialities);
        }

        #endregion

        #region AuditoriumTypes

        public IQueryable<AuditoriumType> GetAuditoriumTypes()
        {
            return Database.AuditoriumTypes;
        }

        #endregion

        #region Schedules

        public IQueryable<Schedule> GetSchedulesForAll(
                                Lecturer lecturer, 
                                Auditorium auditorium,
                                IEnumerable<Group> groups,
                                WeekType weekType,
                                string subGroup,
                                DateTime startDate,
                                DateTime endDate
                                )
        {
            var result = GetSchedules().Where(x => x.IsActual);
            if(lecturer != null)
                result = result.Where(x => x.ScheduleInfo.Lecturer.Id == lecturer.Id);
            if(auditorium != null)
                result = result.Where(x => x.Auditorium.Id == auditorium.Id);
            foreach(var group in groups)
                    result = result.Where(x => x.ScheduleInfo.Groups.Any(y => y.Id == group.Id));
            if(subGroup != null)
                    result = result.Where(x => x.SubGroup == null || x.SubGroup == subGroup);
            if(startDate != null)
                    result = result.Where(x => x.EndDate >= startDate);
            if(endDate != null)
                    result = result.Where(x => x.StartDate <= endDate);

            if(weekType != null)
                    if(weekType.Id == 2)
                        result = result.Where(x => x.WeekType.Id != 3);
                    else if(weekType.Id == 3)
                        result = result.Where(x => x.WeekType.Id != 2);
                    
            //TODO: order by priority
            var query = result.GroupBy(x => new { x.DayOfWeek, x.Period.Id });

            //TODO: improuve speed
            var answer = new List<Schedule>();
            foreach(var q in query)
                answer.Add(q.OrderBy(x => x.CreatedDate).First());

            return answer.AsQueryable();
        }


        public IQueryable<Schedule> GetSchedulesForDayTimeDate(
                                int? dayOfWeek, 
                                Time period,
                                WeekType weekType,
                                Lecturer lecturer, 
                                Auditorium auditorium,
                                IEnumerable<Group> groups,
                                string subGroup,
                                DateTime startDate,
                                DateTime endDate
            )
        {
            var result = GetSchedules().Where(x => x.IsActual);

            if (dayOfWeek != null)
                result = result.Where(x => x.DayOfWeek == dayOfWeek);

            if(period != null)
                result = result.Where(x => x.Period.Id == period.Id);

            if (lecturer != null)
                result = result.Where(x => x.ScheduleInfo.Lecturer.Id == lecturer.Id);
            if (auditorium != null)
                result = result.Where(x => x.Auditorium.Id == auditorium.Id);
            foreach (var group in groups)
                result = result.Where(x => x.ScheduleInfo.Groups.Any(y => y.Id == group.Id));
            if (subGroup != null)
                result = result.Where(x => x.SubGroup == null || x.SubGroup == subGroup);

            if (startDate != null)
                result = result.Where(x => x.EndDate >= startDate);
            if (endDate != null)
                result = result.Where(x => x.StartDate <= endDate);

            //TODO: order by priority
            return result.OrderBy(x => x.CreatedDate);
        }

        public int CountScheduleCollisions(
            int day,
            Time time,
            WeekType weekType)
        {
            return Database.Schedules.Count(x => x.Period.Id.Equals(time.Id) && x.DayOfWeek.Equals(day) &&
                (x.WeekType.Id == 1 || x.WeekType.Id == weekType.Id));
        }

        public IQueryable<Schedule> GetSchedulesByDayTime(int day, Time time)
        {
            return GetSchedules()
                .Where(x => (x.DayOfWeek == day && x.Period.Id == time.Id));
        }

        public IQueryable<Schedule> GetSchedulesForCourse(
            Faculty faculty,
            Course course,
            StudyYear studyYear,
            int semester,
            DateTime StartDate,
            DateTime EndDate)
        {
            return GetSchedules()
                .Where(x => x.ScheduleInfo.StudyYear.Id == studyYear.Id)
                .Where(x => x.ScheduleInfo.Semester == semester)
                .Where(x => x.ScheduleInfo.Faculties.Any(y => y.Id.Equals(faculty.Id))
                            && x.ScheduleInfo.Courses.Any(y => y.Id.Equals(course.Id)));

        }

        public IQueryable<Schedule> GetSchedulesForGroup(
            Faculty faculty,
            Course course,
            Group group,
            StudyYear studyYear,
            int semester,
            DateTime StartDate,
            DateTime EndDate,
            string SubGroup)
        {
            var result =  GetSchedules()
                .Where(x => x.ScheduleInfo.StudyYear.Id == studyYear.Id)
                .Where(x => x.ScheduleInfo.Semester == semester)
                .Where(x => x.ScheduleInfo.Faculties.Any(y => y.Id.Equals(faculty.Id))
                            && x.ScheduleInfo.Courses.Any(y => y.Id.Equals(course.Id))
                            && x.ScheduleInfo.Groups.Any(y => y.Id.Equals(group.Id)));
            if (SubGroup != null)
                result = result.Where(x => x.SubGroup == SubGroup);

            return result;
        }

        public IQueryable<Schedule> GetSchedulesForGroupOnlyId(
           Group group,
           StudyYear studyYear,
           int semester,
           DateTime StartDate,
           DateTime EndDate)
        {
            return GetSchedules()
                .Where(x => x.ScheduleInfo.StudyYear.Id == studyYear.Id)
                .Where(x => x.ScheduleInfo.Semester == semester)
                .Where(x => x.StartDate <= EndDate && x.EndDate >= StartDate)
                .Where(x => x.ScheduleInfo.Groups.Any(y => y.Id.Equals(group.Id)));

        }

        public IQueryable<Schedule> GetSchedulesForSpeciality(
            Faculty faculty,
            Course course,
            Speciality speciality,
            StudyYear studyYear,
            int semester,
            DateTime StartDate,
            DateTime EndDate)
        {
            return GetSchedules()
                .Where(x => x.ScheduleInfo.StudyYear.Id == studyYear.Id)
                .Where(x => x.ScheduleInfo.Semester == semester)
                .Where(x => x.ScheduleInfo.Faculties.Any(y => y.Id.Equals(faculty.Id))
                            && x.ScheduleInfo.Courses.Any(y => y.Id.Equals(course.Id))
                            && x.ScheduleInfo.Specialities.Any(y => y.Id.Equals(speciality.Id)));

        }

        public IQueryable<Schedule> GetSchedulesForLecturer(
            Lecturer lecturer,
            StudyYear studyYear,
            int semester,
            DateTime StartDate,
            DateTime EndDate)
        {
            var result =  GetSchedules()
                .Where(x => x.ScheduleInfo.StudyYear.Id == studyYear.Id)
                .Where(x => x.ScheduleInfo.Semester == semester)
                .Where(x => x.ScheduleInfo.Lecturer.Id.Equals(lecturer.Id));

            return result;
        }

        public IQueryable<Schedule> GetSchedulesForAuditorium(
            Auditorium auditorium,
            StudyYear studyYear,
            int semester,
            DateTime StartDate,
            DateTime EndDate)
        {
            var result = GetSchedules()
               .Where(x => x.ScheduleInfo.StudyYear.Id == studyYear.Id)
               .Where(x => x.ScheduleInfo.Semester == semester)
               .Where(x => x.Auditorium.Id.Equals(auditorium.Id));

         
            return result;
        }


        public int CountSchedulesForScheduleInfoes(ScheduleInfo scheduleInfo)
        {
            return Database.Schedules.Count(x => x.ScheduleInfo.Id.Equals(scheduleInfo.Id));
        }

        public IQueryable<Schedule> GetSchedulesForScheduleInfoes(ScheduleInfo scheduleInfo)
        {
            return GetSchedules()
                .Where(x => x.ScheduleInfo.Id.Equals(scheduleInfo.Id));
        }

        public Schedule GetScheduleById(int id)
        {
            return GetSchedules()
                .FirstOrDefault(schedule => schedule.Id == id);

        }

        private IQueryable<Schedule> GetSchedules()
        {
            return Database.Schedules
                .Include(x => x.ScheduleInfo)
                .Include(x => x.ScheduleInfo.Lecturer)
                .Include(x => x.ScheduleInfo.Tutorial)
                .Include(x => x.ScheduleInfo.TutorialType)
                .Include(x => x.ScheduleInfo.Courses)
                .Include(x => x.ScheduleInfo.Groups)
                .Include(x => x.ScheduleInfo.Faculties)
                .Include(x => x.WeekType)
                .Include(x => x.Auditorium)
                .Include(x => x.Period);
        }

        #endregion

        #region Tutorial

        public Tutorial GetTutorialById(Tutorial tutorial)
        {
            return Database.Tutorials
                .FirstOrDefault(x => x.Id == tutorial.Id);
        }

        public IQueryable<Tutorial> GetTutorialsForGroup(
            Faculty faculty,
            Course course,
            Group group)
        {
            return Database.ScheduleInfoes
                .Where(x => x.Faculties.Any(y => y.Id == faculty.Id))
                .Where(x => x.Courses.Any(y => y.Id == course.Id))
                .Where(x => x.Groups.Any(y => y.Id == group.Id))
                .Select(x => x.Tutorial);
        }

        public IQueryable<Tutorial> GetTutorialsForSpeciality(
            Faculty faculty,
            Course course,
            Speciality speciality)
        {
            return Database.ScheduleInfoes
                .Where(x => x.Faculties.Any(y => y.Id == faculty.Id))
                .Where(x => x.Courses.Any(y => y.Id == course.Id))
                .Where(x => x.Specialities.Any(y => y.Id == speciality.Id))
                .Select(x => x.Tutorial);
        }

        public IQueryable<Tutorial> GetTutorialsForCourse(
            Faculty faculty,
            Course course)
        {
            return Database.ScheduleInfoes
                .Where(x => x.Faculties.Any(y => y.Id == faculty.Id))
                .Where(x => x.Courses.Any(y => y.Id == course.Id))
                .Select(x => x.Tutorial);
        }

        #endregion

        public IQueryable<Speciality> GetSpecialities(Faculty faculty)
        {
            return Database.Specialities
                .Where(x => x.Faculties
                    .Any(y => y.Id.Equals(faculty.Id)));
        }

        public IQueryable<Time> GetTimes(Building building)
        {
            return Database.Times
                .Where(x => x.Building.Id.Equals(building.Id))
                .Include(x => x.Building);
        }

        public IQueryable<TutorialType> GetTutorialTypes()
        {
            return Database.TutorialTypes;
        }

        public TutorialType GetTutorialTypeById(TutorialType tutorialType)
        {
            return Database.TutorialTypes
                .FirstOrDefault(x => x.Id == tutorialType.Id);
        }

        public IQueryable<WeekType> GetWeekTypes()
        {
            return Database.WeekTypes;
        }

        public IQueryable<StudyYear> GetStudyYears()
        {
            return Database.StudyYears;
        }

        #endregion

        #region test

        public void AddBlockScheduleForAuditorium(int AuditoriumId, 
                                                  int DayOfWeek, 
                                                  int PeriodId, 
                                                  int WeekTypeId, 
                                                  DateTime StartDate,
                                                  DateTime EndDate)
        {
            var schedule = new Schedule();
            schedule.AuditoriumId = AuditoriumId;
            schedule.DayOfWeek = DayOfWeek;
            schedule.PeriodId = PeriodId;
            schedule.WeekTypeId = WeekTypeId;
            schedule.StartDate = StartDate;
            schedule.EndDate = EndDate;
            schedule.CreatedDate = DateTime.Now.Date;
            schedule.UpdatedDate = DateTime.Now.Date;
            schedule.IsActual = true;
            Database.Add<Schedule>(schedule);
        }

        /*public void AddBlockScheduleForLecturer(int LecturerId,
                                                  int DayOfWeek,
                                                  int PeriodId,
                                                  int WeekTypeId,
                                                  DateTime StartDate,
                                                  DateTime EndDate)
        {
            

            Database.Add<Schedule>(schedule);
        }*/
        

        #endregion
    }
}
