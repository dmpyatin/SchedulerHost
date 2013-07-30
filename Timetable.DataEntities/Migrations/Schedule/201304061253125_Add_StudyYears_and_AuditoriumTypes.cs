using System.Data.Entity.Migrations;

namespace Timetable.Data.Migrations.Schedule
{
    public partial class Add_StudyYears_and_AuditoriumTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditoriumTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActual = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudyYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActual = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ScheduleInfoes", "Semester", c => c.Int(nullable: false));
            AddColumn("dbo.ScheduleInfoes", "StudyYear_Id", c => c.Int());
            AddColumn("dbo.Auditoriums", "AuditoriumType_Id", c => c.Int());
            AddForeignKey("dbo.ScheduleInfoes", "StudyYear_Id", "dbo.StudyYears", "Id");
            AddForeignKey("dbo.Auditoriums", "AuditoriumType_Id", "dbo.AuditoriumTypes", "Id");
            CreateIndex("dbo.ScheduleInfoes", "StudyYear_Id");
            CreateIndex("dbo.Auditoriums", "AuditoriumType_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Auditoriums", new[] { "AuditoriumType_Id" });
            DropIndex("dbo.ScheduleInfoes", new[] { "StudyYear_Id" });
            DropForeignKey("dbo.Auditoriums", "AuditoriumType_Id", "dbo.AuditoriumTypes");
            DropForeignKey("dbo.ScheduleInfoes", "StudyYear_Id", "dbo.StudyYears");
            DropColumn("dbo.Auditoriums", "AuditoriumType_Id");
            DropColumn("dbo.ScheduleInfoes", "StudyYear_Id");
            DropColumn("dbo.ScheduleInfoes", "Semester");
            DropTable("dbo.StudyYears");
            DropTable("dbo.AuditoriumTypes");
        }
    }
}
