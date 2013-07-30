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
    public interface ILecturerService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Lecturer> GetAllForDepartment(int departmentId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Lecturer> GetAllForTutorial(int tutorialId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Lecturer> GetAllForTutorialAndTutorialType(
            int tutorialId, 
            int tutorialTypeId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Lecturer GetByFirstMiddleLastname(string arg);
                 

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Lecturer> GetsByFirstMiddleLastname(string arg);

    }
}
