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
    public class ScheduleMapping : EntityTypeConfiguration<Schedule>
    {
        public ScheduleMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasOptional(x => x.Auditorium)
                .WithMany()
                .HasForeignKey(x => x.AuditoriumId);

            HasRequired(x => x.Period)
                .WithMany()
                .HasForeignKey(x => x.PeriodId);

            HasRequired(x => x.ScheduleInfo)
                .WithMany(x => x.Schedules)
                .HasForeignKey(x => x.ScheduleInfoId);

            HasRequired(x => x.WeekType)
                .WithMany()
                .HasForeignKey(x => x.WeekTypeId);
        }
    }
}
