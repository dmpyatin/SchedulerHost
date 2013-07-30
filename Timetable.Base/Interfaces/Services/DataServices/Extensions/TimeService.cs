using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timetable.Base.Entities;

namespace Timetable.Base.Interfaces.Services.DataServices.Extensions
{
    public static class TimeService
    {
        public static IQueryable<Time> GetTimesByIds(this IDataService<Time> dataService, IEnumerable<int> ids = null)
        {
            if (ids == null)
                return dataService.Repository.Get();
            else
            {
                var result = new List<Time>();

                foreach (int id in ids)
                {
                    var period = dataService.Repository.GetById(id);

                    result.Add(period);
                }

                return result.AsQueryable();
            }
        }
    }
}
