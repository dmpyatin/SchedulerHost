using System.Linq;
using Timetable.Base.Entities.Personalization;

namespace Timetable.Base.Interfaces.DataSources
{
    public interface IUserDatabase: IDatabase
    {
        IQueryable<User> Users { get; }

        IQueryable<UserRole> UserRoles { get; }
    }
}
