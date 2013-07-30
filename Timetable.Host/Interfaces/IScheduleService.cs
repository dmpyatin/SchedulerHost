using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Timetable.Base.Entities;

namespace Timetable.Host.Interfaces
{
    [ServiceContract]
    public interface IScheduleService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetAllForCourse(
            int facultyId, 
            int courseId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetAllForGroup(
            int facultyId,
            int courseId,
            int groupId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetAllForSpeciality(
            int facultyId,
            int courseId,
            int specialityId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetAllForLecturer(int lecturerId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Schedule> GetAllForAuditorium(int auditoriumId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Schedule GetById(int id);
    }
}
