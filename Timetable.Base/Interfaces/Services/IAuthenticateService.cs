using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Timetable.Base.Interfaces.Services
{
    public interface IAuthenticateService
    {
        bool Authenticate(string login, string password);
        bool Authenticate(string login, string password, TimeSpan expiryPeriod);

        event EventHandler OnSuccess;

        event EventHandler OnFail;
    }
}
