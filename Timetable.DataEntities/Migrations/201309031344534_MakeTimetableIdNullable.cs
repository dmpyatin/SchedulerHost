namespace Timetable.Data.Migrations.Schedule
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeTimetableIdNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "TimetableEntityId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "TimetableEntityId", c => c.Int(nullable: false));
        }
    }
}
