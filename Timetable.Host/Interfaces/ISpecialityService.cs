using System.ServiceModel;
using System.ServiceModel.Web;
using Timetable.Base.Entities;

namespace Timetable.Host.Interfaces
{
    [ServiceContract]
    public interface ISpecialityService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        Speciality[] GetAll(int facultyId);
    }
}
