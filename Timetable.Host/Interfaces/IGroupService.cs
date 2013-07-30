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
    public interface IGroupService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Group GetGroupById(int groupId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Group[] GetsGroupsById(int groupId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Group> GetAll(
            int facultyId, 
            int courseId);
    }
}
