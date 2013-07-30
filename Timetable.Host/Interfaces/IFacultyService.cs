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
    public interface IFacultyService
    {
        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Faculty> GetAll();
    }
}
