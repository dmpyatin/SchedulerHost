using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;

namespace Timetable.Data.Migrations
{
    public class NonSystemTableSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void GenerateMakeSystemTable(CreateTableOperation createTableOperation)
        {
        }
    }
}
