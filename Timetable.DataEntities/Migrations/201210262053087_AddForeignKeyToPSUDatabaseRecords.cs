namespace Timetable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeytoPSUdatabaserecords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Faculties", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.ScheduleInfoes", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Specialities", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Groups", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Lecturers", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Ranks", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Auditoriums", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.TutorialTypes", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Tutorials", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Schedules", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Times", "ForeignKey", c => c.Int(nullable: false));
            AddColumn("dbo.Times", "Building_Id", c => c.Int());
            AddColumn("dbo.WeekTypes", "ForeignKey", c => c.Int(nullable: false));
            AddForeignKey("dbo.Times", "Building_Id", "dbo.Buildings", "Id");
            CreateIndex("dbo.Times", "Building_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Times", new[] { "Building_Id" });
            DropForeignKey("dbo.Times", "Building_Id", "dbo.Buildings");
            DropColumn("dbo.WeekTypes", "ForeignKey");
            DropColumn("dbo.Times", "Building_Id");
            DropColumn("dbo.Times", "ForeignKey");
            DropColumn("dbo.Schedules", "ForeignKey");
            DropColumn("dbo.Tutorials", "ForeignKey");
            DropColumn("dbo.Buildings", "ForeignKey");
            DropColumn("dbo.TutorialTypes", "ForeignKey");
            DropColumn("dbo.Auditoriums", "ForeignKey");
            DropColumn("dbo.Ranks", "ForeignKey");
            DropColumn("dbo.Lecturers", "ForeignKey");
            DropColumn("dbo.Groups", "ForeignKey");
            DropColumn("dbo.Specialities", "ForeignKey");
            DropColumn("dbo.Courses", "ForeignKey");
            DropColumn("dbo.ScheduleInfoes", "ForeignKey");
            DropColumn("dbo.Faculties", "ForeignKey");
            DropColumn("dbo.Departments", "ForeignKey");
        }
    }
}
