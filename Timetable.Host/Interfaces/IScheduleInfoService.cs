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
    public interface IScheduleInfoService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<ScheduleInfo> GetAllForCourse(
            int facultyId, 
            int courseId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<ScheduleInfo> GetAllForSpeciality(
            int facultyId,
            int courseId,
            int specialityId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<ScheduleInfo> GetAllForGroup(
            int facultyId,
            int courseId,
            int groupId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<ScheduleInfo> GetAllForDepartment(
            int departmentId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<ScheduleInfo> GetUnscheduled(int facultyId, int courseId, int specialityId, int groupId);
    }
}
