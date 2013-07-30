namespace Timetable.Data.Migrations.Schedule
{
    using System.Data.Entity.Migrations;
    
    public partial class Remove_StudyYear_entity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ScheduleInfoes", "StudyYear_Id", "dbo.StudyYears");
            DropIndex("dbo.ScheduleInfoes", new[] { "StudyYear_Id" });
            AddColumn("dbo.ScheduleInfoes", "StudyYear", c => c.Int(nullable: false));
            DropColumn("dbo.ScheduleInfoes", "StudyYear_Id");
            DropTable("dbo.StudyYears");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.ScheduleInfoes", "StudyYear_Id", c => c.Int());
            DropColumn("dbo.ScheduleInfoes", "StudyYear");
            CreateIndex("dbo.ScheduleInfoes", "StudyYear_Id");
            AddForeignKey("dbo.ScheduleInfoes", "StudyYear_Id", "dbo.StudyYears", "Id");
        }
    }
}
