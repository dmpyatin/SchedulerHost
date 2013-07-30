using System.Data.Entity;
using System.Linq;

using Timetable.Base.Entities;
using Timetable.Base.Entities.Personalization;
using Timetable.Base.Interfaces.DataSources;
using Timetable.Data.Context.Interfaces;

namespace Timetable.Data.Context
{
    public sealed class UserContext: BaseContext, IUserDatabase
    {
        public IDbSet<User> Users { get; set; }

        public IDbSet<UserRole> UserRoles { get; set; }

        public UserContext()
        {
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;
        }

        #region IUserDatabase implementation

        IQueryable<User> IUserDatabase.Users
        {
            get { return Users; }
        }

        IQueryable<UserRole> IUserDatabase.UserRoles
        {
            get { return UserRoles; }
        }

        #endregion
    }
}
