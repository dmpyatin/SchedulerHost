using System.Linq;
using Timetable.Host.Interfaces;


namespace Timetable.Host.Services
{
    public class AuditoriumService : BaseService<Base.Entities.Auditorium>, IAuditoriumService
    {
        public IQueryable<Base.Entities.Auditorium> GetAll(int buildingId)
        {
            return Repository.Get(x => x.Building.Id.Equals(buildingId));
        }
    }
}

