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
    public class FacultyMapping : EntityTypeConfiguration<Faculty>
    {
        public FacultyMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Branch)
                .WithMany(x => x.Faculties)
                .HasForeignKey(x => x.BranchId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Specialities)
                .WithMany(x => x.Faculties)
                .Map(m =>
                {
                    m.MapLeftKey("Faculty_Id");
                    m.MapRightKey("Speciality_Id");
                    m.ToTable("FacultiesToSpecialities");
                });
        }
    }
}
