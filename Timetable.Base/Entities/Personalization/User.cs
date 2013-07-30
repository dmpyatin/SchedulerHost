using System;
using System.Runtime.Serialization;

namespace Timetable.Base.Entities.Personalization
{
    [DataContract]
    public class User: BaseEntity
    {
        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public UserRole Role { get; set; }

        [DataMember]
        public int RoleId { get; set; }
    }
}
