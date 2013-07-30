namespace Timetable.Data.Migrations.Schedule
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_StudyYear_entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudyYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartYear = c.Int(nullable: false),
                        Length = c.Int(nullable: false, defaultValue: 1),
                        IsActual = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ScheduleInfoes", "StudyYear_Id", c => c.Int(nullable: false));
            AddForeignKey("dbo.ScheduleInfoes", "StudyYear_Id", "dbo.StudyYears", "Id");
            CreateIndex("dbo.ScheduleInfoes", "StudyYear_Id");
            DropColumn("dbo.ScheduleInfoes", "StudyYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScheduleInfoes", "StudyYear", c => c.Int(nullable: false));
            DropIndex("dbo.ScheduleInfoes", new[] { "StudyYear_Id" });
            DropForeignKey("dbo.ScheduleInfoes", "StudyYear_Id", "dbo.StudyYears");
            DropColumn("dbo.ScheduleInfoes", "StudyYear_Id");
            DropTable("dbo.StudyYears");
        }
    }
}
