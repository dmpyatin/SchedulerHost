namespace Timetable.Data.Migrations.Schedule
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_sbgroups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "SubGroup", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "SubGroup");
        }
    }
}
