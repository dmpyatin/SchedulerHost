using System.Data.Entity.Migrations;
using Timetable.Data.Context;

namespace Timetable.Data.Migrations.Schedule
{
    public sealed class SchedulerConfiguration : DbMigrationsConfiguration<SchedulerContext>
    {
        public SchedulerConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsNamespace = "Timetable.Data.Migrations.Schedule";
            
            SetSqlGenerator("System.Data.SqlClient", new NonSystemTableSqlGenerator()); 
        }
    }
}
