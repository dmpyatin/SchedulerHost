namespace Timetable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudyYears : DbMigration
    {
        public override void Up()
        {


           // DropIndex("dbo.ScheduleInfoes", new[] { "StudyYear_Id" });
            DropForeignKey("dbo.ScheduleInfoes", "StudyYear_Id", "dbo.StudyYear");
            DropColumn("dbo.ScheduleInfoes", "StudyYear_Id");

            DropTable("dbo.StudyYears");

        }

        public override void Down()
        {
           
           
        }
    }
}
