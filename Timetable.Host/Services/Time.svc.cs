using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Timetable.Base.Entities;
using Timetable.Host.Interfaces;

namespace Timetable.Host.Services
{
    public class TimeService : BaseService<Time>, ITimeService
    {
        public IQueryable<Time> GetAll()
        {
            return Repository.Get();
        }
    }
}
