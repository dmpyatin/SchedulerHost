using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using Timetable.Base.Entities.Scheduler;

namespace Timetable.Host.Interfaces
{
    [ServiceContract]
    public interface IDataService: IBaseService
    {

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetSchedulesForDayTimeDate(
                                int? dayOfWeek,
                                Time period,
                                WeekType weekType,
                                Lecturer lecturer,
                                Auditorium auditorium,
                                IEnumerable<Group> groups,
                                string subGroup,
                                DateTime startDate,
                                DateTime endDate
            );

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetSchedulesForAll(
                                Lecturer lecturer,
                                Auditorium auditorium,
                                IEnumerable<Group> groups,
                                WeekType weekType,
                                string subGroup,
                                DateTime startDate,
                                DateTime endDate
                                );


        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetSchedulesForGroupOnlyId(
           Group group,
           StudyYear studyYear,
           int semester,
           DateTime StartDate,
           DateTime EndDate);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<TimetableEntity> GetTimetableEntities();

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Group> GetGroupsByCode(string code, int count);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        bool ValidateSchedule(Schedule schedule);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Branch> GetBranches();

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Auditorium> GetAuditoriums(
            Building building,
            AuditoriumType auditoriumType);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Auditorium> GetFreeAuditoriums(
            Building building,
            int day,
            WeekType weekType,
            Time time,
            TutorialType tutorialType,
            AuditoriumType auditoriumType,
            int capacity,
            DateTime startDate,
            DateTime endDate);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<AuditoriumType> GetAuditoriumTypes();

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Building> GetBuildings();

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Course> GetCources();

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Department> GetDeparmtents();

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Faculty> GetFaculties(Branch branch = null);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Group GetGroupById(
            int groupId);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Group> GetsSubGroupsByGroupId(
            int groupId);

        [OperationContract(Name = "GetGroupsForCourse")]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Group> GetGroups(
            Faculty faculty,
            Course course);

        [OperationContract(Name = "GetGroupsForSpeciality")]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Group> GetGroups(
            Course course,
            Speciality speciality);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Lecturer> GetLecturersByDeparmentId(
            Department department);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Lecturer> GetLecturersByTutorialId(
            Tutorial tutorial);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Lecturer> GetLecturersByTutorialIdAndTutorialTypeId(
            Tutorial tutorial,
            TutorialType tutorialType);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Lecturer GetLecturerByFirstMiddleLastname(
            string arg);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Lecturer> GetLecturersByFirstMiddleLastname(
            string arg);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetSchedulesForScheduleInfoes(ScheduleInfo scheduleInfo);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        ScheduleInfo GetScheduleInfoById(
            int id);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<ScheduleInfo> GetScheduleInfoesForCourse(
            Faculty faculty,
            Course course,
            StudyYear studyYear, 
            int semester);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<ScheduleInfo> GetScheduleInfoesForSpeciality(
            Faculty faculty,
            Course course,
            Speciality speciality,
            StudyYear studyYear,
            int semester);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<ScheduleInfo> GetScheduleInfoesForGroup(
            Faculty faculty,
            Course course,
            Group group,
            TutorialType tutorialtype,
            StudyYear studyYear,
            int semester);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<ScheduleInfo> GetScheduleInfoesForDepartment(
            Department department,
            StudyYear studyYear,
            int semester);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<ScheduleInfo> GetUnscheduledInfoes(
            Faculty faculty, 
            Course course, 
            Speciality speciality, 
            Group group);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        int CountScheduleCollisions(
            int day, 
            Time time, 
            WeekType weekType);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetSchedulesByDayTime(
            int day,
            Time time);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetSchedulesForCourse(
            Faculty faculty,
            Course course,
            StudyYear studyYear,
            int semester,
            DateTime StartDate,
            DateTime EndDate);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetSchedulesForGroup(
            Faculty faculty,
            Course course,
            Group group,
            StudyYear studyYear,
            int semester,
            DateTime StartDate,
            DateTime EndDate,
            string SubGroup);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        int CountSchedulesForScheduleInfoes(ScheduleInfo scheduleInfo);


        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetSchedulesForSpeciality(
            Faculty faculty,
            Course course,
            Speciality speciality,
            StudyYear studyYear,
            int semester,
            DateTime StartDate,
            DateTime EndDate);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetSchedulesForLecturer(
            Lecturer lecturer,
            StudyYear studyYear,
            int semester,
            DateTime StartDate,
            DateTime EndDate);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetSchedulesForAuditorium(
            Auditorium auditorium,
            StudyYear studyYear,
            int semester,
            DateTime StartDate,
            DateTime EndDate);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Schedule GetScheduleById(int id);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Speciality> GetSpecialities(
            Faculty faculty);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Time> GetTimes(Building building);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Tutorial GetTutorialById(Tutorial tutorial);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Tutorial> GetTutorialsForGroup(
            Faculty faculty,
            Course course,
            Group group);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Tutorial> GetTutorialsForSpeciality(
            Faculty faculty,
            Course course,
            Speciality speciality);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Tutorial> GetTutorialsForCourse(
            Faculty faculty,
            Course course);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<TutorialType> GetTutorialTypes();

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        TutorialType GetTutorialTypeById(TutorialType tutorialType);

        [OperationContract]
        [ApplyDataContractResolver]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<WeekType> GetWeekTypes();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<StudyYear> GetStudyYears();
    }
}
