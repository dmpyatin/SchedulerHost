namespace Timetable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_positions_for_a_lecturers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lecturers", "Rank_Id", "dbo.Ranks");
            DropIndex("dbo.Lecturers", new[] { "Rank_Id" });
            CreateTable(
                "dbo.Positions",
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
                "dbo.PositionToLecturers",
                c => new
                    {
                        Position_Id = c.Int(nullable: false),
                        Lecturer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Position_Id, t.Lecturer_Id })
                .ForeignKey("dbo.Positions", t => t.Position_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lecturers", t => t.Lecturer_Id, cascadeDelete: true)
                .Index(t => t.Position_Id)
                .Index(t => t.Lecturer_Id);
            
            AddColumn("dbo.Departments", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Departments", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Departments", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Faculties", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Faculties", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Faculties", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ScheduleInfoes", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.ScheduleInfoes", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ScheduleInfoes", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Courses", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Courses", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Courses", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Specialities", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Specialities", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Specialities", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Groups", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Groups", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Groups", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auditoriums", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Auditoriums", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auditoriums", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TutorialTypes", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.TutorialTypes", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TutorialTypes", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Buildings", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Buildings", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Buildings", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedules", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Schedules", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedules", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Times", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Times", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Times", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeekTypes", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.WeekTypes", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeekTypes", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lecturers", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Lecturers", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lecturers", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tutorials", "IsActual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tutorials", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tutorials", "UpdatedDate", c => c.DateTime(nullable: false));
            //DropColumn("dbo.Schedules", "EndDate");
            //DropColumn("dbo.Schedules", "StartDate");
            DropColumn("dbo.Lecturers", "Rank_Id");
            DropTable("dbo.Ranks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Lecturers", "Rank_Id", c => c.Int());
            //AddColumn("dbo.Schedules", "StartDate", c => c.DateTime(nullable: false));
            //AddColumn("dbo.Schedules", "EndDate", c => c.DateTime(nullable: false));
            DropIndex("dbo.PositionLecturers", new[] { "Lecturer_Id" });
            DropIndex("dbo.PositionLecturers", new[] { "Position_Id" });
            DropForeignKey("dbo.PositionLecturers", "Lecturer_Id", "dbo.Lecturers");
            DropForeignKey("dbo.PositionLecturers", "Position_Id", "dbo.Positions");
            DropColumn("dbo.Tutorials", "UpdatedDate");
            DropColumn("dbo.Tutorials", "CreatedDate");
            DropColumn("dbo.Tutorials", "IsActual");
            DropColumn("dbo.Lecturers", "UpdatedDate");
            DropColumn("dbo.Lecturers", "CreatedDate");
            DropColumn("dbo.Lecturers", "IsActual");
            DropColumn("dbo.WeekTypes", "UpdatedDate");
            DropColumn("dbo.WeekTypes", "CreatedDate");
            DropColumn("dbo.WeekTypes", "IsActual");
            DropColumn("dbo.Times", "UpdatedDate");
            DropColumn("dbo.Times", "CreatedDate");
            DropColumn("dbo.Times", "IsActual");
            DropColumn("dbo.Schedules", "UpdatedDate");
            DropColumn("dbo.Schedules", "CreatedDate");
            DropColumn("dbo.Schedules", "IsActual");
            DropColumn("dbo.Buildings", "UpdatedDate");
            DropColumn("dbo.Buildings", "CreatedDate");
            DropColumn("dbo.Buildings", "IsActual");
            DropColumn("dbo.TutorialTypes", "UpdatedDate");
            DropColumn("dbo.TutorialTypes", "CreatedDate");
            DropColumn("dbo.TutorialTypes", "IsActual");
            DropColumn("dbo.Auditoriums", "UpdatedDate");
            DropColumn("dbo.Auditoriums", "CreatedDate");
            DropColumn("dbo.Auditoriums", "IsActual");
            DropColumn("dbo.Groups", "UpdatedDate");
            DropColumn("dbo.Groups", "CreatedDate");
            DropColumn("dbo.Groups", "IsActual");
            DropColumn("dbo.Specialities", "UpdatedDate");
            DropColumn("dbo.Specialities", "CreatedDate");
            DropColumn("dbo.Specialities", "IsActual");
            DropColumn("dbo.Courses", "UpdatedDate");
            DropColumn("dbo.Courses", "CreatedDate");
            DropColumn("dbo.Courses", "IsActual");
            DropColumn("dbo.ScheduleInfoes", "UpdatedDate");
            DropColumn("dbo.ScheduleInfoes", "CreatedDate");
            DropColumn("dbo.ScheduleInfoes", "IsActual");
            DropColumn("dbo.Faculties", "UpdatedDate");
            DropColumn("dbo.Faculties", "CreatedDate");
            DropColumn("dbo.Faculties", "IsActual");
            DropColumn("dbo.Departments", "UpdatedDate");
            DropColumn("dbo.Departments", "CreatedDate");
            DropColumn("dbo.Departments", "IsActual");
            DropTable("dbo.PositionLecturers");
            DropTable("dbo.Positions");
            CreateIndex("dbo.Lecturers", "Rank_Id");
            AddForeignKey("dbo.Lecturers", "Rank_Id", "dbo.Ranks", "Id");
        }
    }
}
