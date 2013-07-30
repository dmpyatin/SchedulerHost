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
    public class SpecialityMapping : EntityTypeConfiguration<Speciality>
    {
        public SpecialityMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //HasMany(c => c.ScheduleInfoes).
            //    WithMany(p => p.Specialities).
            //    Map(m =>
            //    {
            //        m.MapLeftKey("Speciality_Id");
            //        m.MapRightKey("ScheduleInfo_Id");
            //        m.ToTable("ScheduleInfoesToSpecialities");
            //    });

            //HasMany(x => x.Faculties)
            //    .WithMany(x => x.Specialities)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("Speciality_Id");
            //        m.MapRightKey("Faculty_Id");
            //        m.ToTable("FacultiesToSpecialities");
            //    });

            //HasMany(x => x.Groups)
            //    .WithOptional()
            //    .HasForeignKey(x => x.SpecialityId);
        }
    }
}
