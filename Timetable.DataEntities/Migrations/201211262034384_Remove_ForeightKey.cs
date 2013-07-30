namespace Timetable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_ForeightKey : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Departments", "ForeignKey");
            DropColumn("dbo.Faculties", "ForeignKey");
            DropColumn("dbo.ScheduleInfoes", "ForeignKey");
            DropColumn("dbo.Courses", "ForeignKey");
            DropColumn("dbo.Specialities", "ForeignKey");
            DropColumn("dbo.Groups", "ForeignKey");
            DropColumn("dbo.Auditoriums", "ForeignKey");
            DropColumn("dbo.TutorialTypes", "ForeignKey");
            DropColumn("dbo.Buildings", "ForeignKey");
            DropColumn("dbo.Schedules", "ForeignKey");
            DropColumn("dbo.Times", "ForeignKey");
            DropColumn("dbo.WeekTypes", "ForeignKey");
            DropColumn("dbo.Lecturers", "ForeignKey");
            DropColumn("dbo.Ranks", "ForeignKey");
            DropColumn("dbo.Tutorials", "ForeignKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tutorials", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Ranks", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Lecturers", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.WeekTypes", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Times", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Schedules", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.TutorialTypes", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Auditoriums", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Groups", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Specialities", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.ScheduleInfoes", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Faculties", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Departments", "ForeignKey", c => c.Int(nullable: false));
        }
    }
}
