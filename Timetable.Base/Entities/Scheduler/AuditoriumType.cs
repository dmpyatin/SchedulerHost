using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Base.Entities.Scheduler
{
    [DataContract(IsReference = true)]
    public class AuditoriumType : BaseEntity
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Auditoriums")]
        public virtual ICollection<Auditorium> Auditoriums { get; set; }
    }
}
