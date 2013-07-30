using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Personalization
{
    [DataContract]
    public enum UserRoleTypes
    {
        Banned,

        Dispatcher,

        Administration
    }
}
