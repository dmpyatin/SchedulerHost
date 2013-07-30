using System.Data.Entity.Migrations;

namespace Timetable.Data.Migrations.Schedule
{
    public partial class Create_many_to_many_for_lecturers_and_departments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lecturers", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.PositionToLecturers", "Position_Id", "dbo.Lecturers");

            DropIndex("dbo.Lecturers", new[] { "Department_Id" });
            DropIndex("dbo.PositionToLecturers", new[] { "Position_Id" });
            DropIndex("dbo.PositionToLecturers", new[] { "Lecturer_Id" });

            DropPrimaryKey("dbo.PositionToLecturers", new[] { "Position_Id", "Lecturer_Id" });

            RenameTable(name: "dbo.ScheduleInfosToFaculties", newName: "ScheduleInfoesToFaculties");
            RenameTable(name: "dbo.ScheduleInfosToCourses", newName: "ScheduleInfoesToCourses");
            RenameTable(name: "dbo.ScheduleInfosToSpecialities", newName: "ScheduleInfoesToSpecialities");
            RenameTable(name: "dbo.ScheduleInfosToGroups", newName: "ScheduleInfoesToGroups");
            RenameTable(name: "dbo.SheduleInfosToAuditoriums", newName: "ScheduleInfoesToAuditoriums");
            RenameTable(name: "dbo.PositionToLecturers", newName: "LecturersToPositions");
           
            RenameColumn(table: "dbo.LecturersToPositions", name: "Position_Id", newName: "Lecturer_Id1");
            RenameColumn(table: "dbo.LecturersToPositions", name: "Lecturer_Id", newName: "Position_Id");
            RenameColumn(table: "dbo.LecturersToPositions", name: "Lecturer_Id1", newName: "Lecturer_Id");

            CreateTable(
                "dbo.LecturersToDepartments",
                c => new
                    {
                        Lecturer_Id = c.Int(nullable: false),
                        Department_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lecturer_Id, t.Department_Id })
                .ForeignKey("dbo.Lecturers", t => t.Lecturer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .Index(t => t.Lecturer_Id)
                .Index(t => t.Department_Id);
            
            
            AddPrimaryKey("dbo.LecturersToPositions", new[] { "Lecturer_Id", "Position_Id" });
            AddForeignKey("dbo.LecturersToPositions", "Lecturer_Id", "dbo.Lecturers", "Id", cascadeDelete: true);
            CreateIndex("dbo.LecturersToPositions", "Lecturer_Id");
            DropColumn("dbo.Lecturers", "Department_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lecturers", "Department_Id", c => c.Int());
            DropIndex("dbo.LecturersToPositions", new[] { "Lecturer_Id" });
            DropIndex("dbo.LecturersToDepartments", new[] { "Department_Id" });
            DropIndex("dbo.LecturersToDepartments", new[] { "Lecturer_Id" });
            DropForeignKey("dbo.LecturersToPositions", "Lecturer_Id", "dbo.Lecturers");
            DropForeignKey("dbo.LecturersToDepartments", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.LecturersToDepartments", "Lecturer_Id", "dbo.Lecturers");
            DropPrimaryKey("dbo.LecturersToPositions", new[] { "Lecturer_Id", "Position_Id" });
            AddPrimaryKey("dbo.PositionToLecturers", new[] { "Position_Id", "Lecturer_Id" });
            DropTable("dbo.LecturersToDepartments");
            RenameColumn(table: "dbo.LecturersToPositions", name: "Position_Id", newName: "Lecturer_Id");
            RenameColumn(table: "dbo.LecturersToPositions", name: "Lecturer_Id", newName: "Position_Id");
            CreateIndex("dbo.PositionToLecturers", "Position_Id");
            CreateIndex("dbo.Lecturers", "Department_Id");
            AddForeignKey("dbo.PositionToLecturers", "Position_Id", "dbo.Lecturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lecturers", "Department_Id", "dbo.Departments", "Id");
            RenameTable(name: "dbo.LecturersToPositions", newName: "PositionToLecturers");
            RenameTable(name: "dbo.ScheduleInfoesToAuditoriums", newName: "SheduleInfosToAuditoriums");
            RenameTable(name: "dbo.ScheduleInfoesToGroups", newName: "ScheduleInfosToGroups");
            RenameTable(name: "dbo.ScheduleInfoesToSpecialities", newName: "ScheduleInfosToSpecialities");
            RenameTable(name: "dbo.ScheduleInfoesToCourses", newName: "ScheduleInfosToCourses");
            RenameTable(name: "dbo.ScheduleInfoesToFaculties", newName: "ScheduleInfosToFaculties");
        }
    }
}
