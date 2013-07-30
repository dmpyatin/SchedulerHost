namespace Timetable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStartEndDatesToScheduleInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleInfoes", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ScheduleInfoes", "EndDate", c => c.DateTime(nullable: false));
            //DropColumn("dbo.Schedules", "StartDate");
            //DropColumn("dbo.Schedules", "EndDate");
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduleInfoes", "EndDate");
            DropColumn("dbo.ScheduleInfoes", "StartDate");
            AddColumn("dbo.Schedules", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedules", "EndDate", c => c.DateTime(nullable: false));
        }
    }
}
