using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Timetable.Base.Entities;
using Timetable.Base.Interfaces.Services.DataServices;
using Timetable.Host.Interfaces;

namespace Timetable.Host.Services
{
    public class FacultyService : BaseService<Faculty>, IFacultyService
    {
        public IQueryable<Faculty> GetAll()
        {
            var result = Repository.Get(null,null,"ScheduleInfoes");
            return result.AsQueryable();
        }
    }
}
