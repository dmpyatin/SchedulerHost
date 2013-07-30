using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Base.Entities.Scheduler;

namespace Timetable.Data.Mapping
{
    public class LecturersMapping : EntityTypeConfiguration<Lecturer>
    {
        public LecturersMapping()
        {
            HasMany(x => x.Positions)
                .WithMany(x => x.Lecturers)
                .Map(m =>
                {
                    m.MapLeftKey("Lecturer_Id");
                    m.MapRightKey("Position_Id");
                    m.ToTable("LecturersToPositions");
                });

            HasMany(x => x.Departments)
                .WithMany(x => x.Lecturers)
                .Map(m => 
                {
                    m.MapLeftKey("Lecturer_Id");
                    m.MapRightKey("Department_Id");
                    m.ToTable("LecturersToDepartments");
                });
        }
    }
}
