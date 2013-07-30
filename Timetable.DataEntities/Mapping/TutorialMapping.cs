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
    public class TutorialMapping : EntityTypeConfiguration<Tutorial>
    {
        public TutorialMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasOptional(x => x.Faculty)
                .WithMany()
                .HasForeignKey(x => x.FacultyId);

            HasOptional(x => x.Speciality)
                .WithMany()
                .HasForeignKey(x => x.SpecialityId);

            HasMany(x => x.ScheduleInfoes)
                .WithRequired(x => x.Tutorial)
                .HasForeignKey(x => x.TutorialId);
        }
    }
}
