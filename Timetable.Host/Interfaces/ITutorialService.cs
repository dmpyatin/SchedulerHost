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
    public interface ITutorialService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Tutorial GetTutorialById(int tutorialId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Tutorial> GetsTutorialsById(int tutorialId);


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Tutorial> GetAllForGroup(
            int facultyId, 
            int courseId, 
            int groupId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Tutorial> GetAllForSpeciality(
            int facultyId,
            int courseId,
            int specialityId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Tutorial> GetAllForCourse(
            int facultyId,
            int courseId);
    }
}
