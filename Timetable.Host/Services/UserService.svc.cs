using System.Linq;
using Timetable.Base.Entities.Personalization;
using Timetable.Base.Interfaces.DataSources;
using Timetable.Host.Interfaces;

namespace Timetable.Host.Services
{
    public class UserService : BaseService<IUserDatabase>, IUserService
    {
        #region Operations implementation

        public bool ValidateUser(string login, string password)
        {
            //return login.ToLower().Equals("admin") 
            //    && password.Equals("Admin");

            return Database.Users
                .Any(x => x.Login == login && x.Password == password);
        }

        public User GetUserByLogin(string login)
        {
            return Database.Users
                .FirstOrDefault(x => x.Login == login);
        }

        #endregion
    }
}
