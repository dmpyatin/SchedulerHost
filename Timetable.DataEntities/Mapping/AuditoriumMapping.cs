using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Base.Entities.Scheduler;

namespace Timetable.Data.Mapping
{
    public class AuditoriumMapping : EntityTypeConfiguration<Auditorium>
    {
        public AuditoriumMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.AuditoriumType)
                .WithMany(x => x.Auditoriums)
                .HasForeignKey(x => x.AuditoriumTypeId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Building)
                .WithMany()
                .HasForeignKey(x => x.BuildingId)
                .WillCascadeOnDelete(false);
        }
    }
}
