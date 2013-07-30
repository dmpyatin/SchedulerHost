namespace Timetable.Data.Migrations.Schedule
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStartEndTimeToSchedules : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedules", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "EndDate");
            DropColumn("dbo.Schedules", "StartDate");
        }
    }
}
