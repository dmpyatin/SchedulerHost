namespace Timetable.Data.Migrations.Schedule
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreign_keys_updated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Faculties", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.ScheduleInfoes", "Lecturer_Id", "dbo.Lecturers");
            DropForeignKey("dbo.Auditoriums", "AuditoriumType_Id", "dbo.AuditoriumTypes");
            DropIndex("dbo.Faculties", new[] { "Branch_Id" });
            DropIndex("dbo.ScheduleInfoes", new[] { "Lecturer_Id" });
            DropIndex("dbo.Auditoriums", new[] { "AuditoriumType_Id" });
            RenameColumn(table: "dbo.Departments", name: "Faculty_Id", newName: "FacultyId");
            RenameColumn(table: "dbo.ScheduleInfoes", name: "TutorialType_Id", newName: "TutorialTypeId");
            RenameColumn(table: "dbo.ScheduleInfoes", name: "Department_Id", newName: "DepartmentId");
            RenameColumn(table: "dbo.ScheduleInfoes", name: "Tutorial_Id", newName: "TutorialId");
            RenameColumn(table: "dbo.ScheduleInfoes", name: "StudyYear_Id", newName: "StudyYearId");
            RenameColumn(table: "dbo.Groups", name: "Course_Id", newName: "CourseId");
            RenameColumn(table: "dbo.Groups", name: "Speciality_Id", newName: "SpecialityId");
            RenameColumn(table: "dbo.Auditoriums", name: "Building_Id", newName: "BuildingId");
            RenameColumn(table: "dbo.Schedules", name: "Auditorium_Id", newName: "AuditoriumId");
            RenameColumn(table: "dbo.Schedules", name: "Period_Id", newName: "PeriodId");
            RenameColumn(table: "dbo.Schedules", name: "ScheduleInfo_Id", newName: "ScheduleInfoId");
            RenameColumn(table: "dbo.Schedules", name: "WeekType_Id", newName: "WeekTypeId");
            RenameColumn(table: "dbo.Times", name: "Building_Id", newName: "BuildingId");
            RenameColumn(table: "dbo.Tutorials", name: "Faculty_Id", newName: "FacultyId");
            RenameColumn(table: "dbo.Tutorials", name: "Speciality_Id", newName: "SpecialityId");
            //AddColumn("dbo.Faculties", "BranchId", c => c.Int(nullable: false));
            //AddColumn("dbo.ScheduleInfoes", "LecturerId", c => c.Int(nullable: false));
            //AddColumn("dbo.Auditoriums", "AuditoriumTypeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Faculties", name: "Branch_Id", newName: "BranchId");
            RenameColumn(table: "dbo.ScheduleInfoes", name: "Lecturer_Id", newName: "LecturerId");
            RenameColumn(table: "dbo.Auditoriums", name: "AuditoriumType_Id", newName: "AuditoriumTypeId");
            AddForeignKey("dbo.Faculties", "BranchId", "dbo.Branches", "Id");
            AddForeignKey("dbo.ScheduleInfoes", "LecturerId", "dbo.Lecturers", "Id");
            AddForeignKey("dbo.Auditoriums", "AuditoriumTypeId", "dbo.AuditoriumTypes", "Id");
            CreateIndex("dbo.Faculties", "BranchId");
            CreateIndex("dbo.ScheduleInfoes", "LecturerId");
            CreateIndex("dbo.Auditoriums", "AuditoriumTypeId");

        }

        public override void Down()
        {
            //AddColumn("dbo.Auditoriums", "AuditoriumType_Id", c => c.Int());
            //AddColumn("dbo.ScheduleInfoes", "Lecturer_Id", c => c.Int());
            //AddColumn("dbo.Faculties", "Branch_Id", c => c.Int());
            DropIndex("dbo.Auditoriums", new[] { "AuditoriumTypeId" });
            DropIndex("dbo.ScheduleInfoes", new[] { "LecturerId" });
            DropIndex("dbo.Faculties", new[] { "BranchId" });
            DropForeignKey("dbo.Auditoriums", "AuditoriumTypeId", "dbo.AuditoriumTypes");
            DropForeignKey("dbo.ScheduleInfoes", "LecturerId", "dbo.Lecturers");
            DropForeignKey("dbo.Faculties", "BranchId", "dbo.Branches");
            //DropColumn("dbo.Auditoriums", "AuditoriumTypeId");
            //DropColumn("dbo.ScheduleInfoes", "LecturerId");
            //DropColumn("dbo.Faculties", "BranchId");
            RenameColumn(table: "dbo.Faculties", name: "BranchId", newName: "Branch_Id");
            RenameColumn(table: "dbo.ScheduleInfoes", name: "LecturerId", newName: "Lecturer_Id");
            RenameColumn(table: "dbo.Auditoriums", name: "AuditoriumTypeId", newName: "AuditoriumType_Id");
            RenameColumn(table: "dbo.Tutorials", name: "SpecialityId", newName: "Speciality_Id");
            RenameColumn(table: "dbo.Tutorials", name: "FacultyId", newName: "Faculty_Id");
            RenameColumn(table: "dbo.Times", name: "BuildingId", newName: "Building_Id");
            RenameColumn(table: "dbo.Schedules", name: "WeekTypeId", newName: "WeekType_Id");
            RenameColumn(table: "dbo.Schedules", name: "ScheduleInfoId", newName: "ScheduleInfo_Id");
            RenameColumn(table: "dbo.Schedules", name: "PeriodId", newName: "Period_Id");
            RenameColumn(table: "dbo.Schedules", name: "AuditoriumId", newName: "Auditorium_Id");
            RenameColumn(table: "dbo.Auditoriums", name: "BuildingId", newName: "Building_Id");
            RenameColumn(table: "dbo.Groups", name: "SpecialityId", newName: "Speciality_Id");
            RenameColumn(table: "dbo.Groups", name: "CourseId", newName: "Course_Id");
            RenameColumn(table: "dbo.ScheduleInfoes", name: "StudyYearId", newName: "StudyYear_Id");
            RenameColumn(table: "dbo.ScheduleInfoes", name: "TutorialId", newName: "Tutorial_Id");
            RenameColumn(table: "dbo.ScheduleInfoes", name: "DepartmentId", newName: "Department_Id");
            RenameColumn(table: "dbo.ScheduleInfoes", name: "TutorialTypeId", newName: "TutorialType_Id");
            RenameColumn(table: "dbo.Departments", name: "FacultyId", newName: "Faculty_Id");
            CreateIndex("dbo.Auditoriums", "AuditoriumType_Id");
            CreateIndex("dbo.ScheduleInfoes", "Lecturer_Id");
            CreateIndex("dbo.Faculties", "Branch_Id");
            AddForeignKey("dbo.Auditoriums", "AuditoriumType_Id", "dbo.AuditoriumTypes", "Id");
            AddForeignKey("dbo.ScheduleInfoes", "Lecturer_Id", "dbo.Lecturers", "Id");
            AddForeignKey("dbo.Faculties", "Branch_Id", "dbo.Branches", "Id");
        }
    }
}
