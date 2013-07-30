using System.ServiceModel;
using System.ServiceModel.Web;
using Timetable.Base.Entities;

namespace Timetable.Host.Interfaces
{
    [ServiceContract]
    public interface IWeekType
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        WeekType[] GetAll();
    }
}
