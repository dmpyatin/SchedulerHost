namespace Timetable.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AuditoriumCapacityIsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auditoriums", "Capacity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Auditoriums", "Capacity", c => c.Int(nullable: false));
        }
    }
}
