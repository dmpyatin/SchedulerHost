using System.Collections.Generic;
using System.Linq;
using Timetable.Base.Entities;
using Timetable.Base.Exceptions;

namespace Timetable.Base.Interfaces.Services.DataServices.Extensions
{
    public static class AuditoriumService
    {
        public static Auditorium GetByNumber(this IDataService<Auditorium> dataService, string number, int buildingId)
        {
            var query = dataService.Repository.Get(filter => filter.Number == number && filter.Building.Id == buildingId, null, "Building");

            var result = query.FirstOrDefault();

            if (result == null)
                throw new EntityNotFoundException();

            return result;
        }


        public static IEnumerable<Auditorium> GetByNumbers(this IDataService<Auditorium> dataService, string[] numbers, int buildingId = 1)
        {
            IQueryable<Auditorium> result = null;

            foreach (var number in numbers)
            {
                var query = dataService.Repository.Get(filter => filter.Number == number && filter.Building.Id == buildingId, null, "Building");
                if (result != null)
                    result = result.Concat(query);
                else
                    result = query;
            }

            return result;
        }
    }

    public class AuditoriumEqualityComparer: IEqualityComparer<Auditorium>
    {

        public bool Equals(Auditorium x, Auditorium y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Auditorium obj)
        {
            return obj.GetHashCode();
        }
    }
}
