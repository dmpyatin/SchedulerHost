using System;
using System.Linq;
using NUnit.Framework;
using Timetable.Host.Tests.PublishedUserService;

namespace Scheduler.Tests
{
    [TestFixture]
    public class UserServiceShould
    {
        [Test]
        public void CreateNewUser()
        {          

            var user = new User();
            user.Login = "Test login";
            user.Password = "Test password";
            user.CreatedDate = DateTime.Now;
            user.UpdateDate = DateTime.Now;

            var userService = new UserServiceClient();
            userService.Add(user);
        }
    }
}
