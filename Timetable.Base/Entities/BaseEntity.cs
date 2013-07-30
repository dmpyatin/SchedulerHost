using System;
using System.Runtime.Serialization;

namespace Timetable.Base.Entities
{
    [DataContract(IsReference = true)]
    public abstract class BaseEntity
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "IsActual")]
        public bool IsActual { get; set; }

        [DataMember(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DataMember(Name = "UpdateDate")]
        public DateTime UpdatedDate { get; set; }
    }
}
