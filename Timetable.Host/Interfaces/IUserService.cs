using System.ServiceModel;
using Timetable.Base.Entities;
using Timetable.Base.Entities.Personalization;

namespace Timetable.Host.Interfaces
{
    [ServiceContract]
    public interface IUserService: IBaseService
    {
        [OperationContract]
        bool ValidateUser(string login, string password);

        [OperationContract]
        User GetUserByLogin(string login);
    }
}
