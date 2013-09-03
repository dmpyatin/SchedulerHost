namespace Timetable.Data.Migrations.Schedule
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTimetaeEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimetableEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsActual = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Schedules", "TimetableEntityId", c => c.Int(nullable: true));
            AddForeignKey("dbo.Schedules", "TimetableEntityId", "dbo.TimetableEntities", "Id");
            CreateIndex("dbo.Schedules", "TimetableEntityId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Schedules", new[] { "TimetableEntityId" });
            DropForeignKey("dbo.Schedules", "TimetableEntityId", "dbo.TimetableEntities");
            DropColumn("dbo.Schedules", "TimetableEntityId");
            DropTable("dbo.TimetableEntities");
        }
    }
}
