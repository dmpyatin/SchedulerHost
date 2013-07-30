namespace Timetable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Active = c.Boolean(nullable: false),
                        LastVisit = c.DateTime(nullable: false),
                        Registration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Faculty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.Faculty_Id, cascadeDelete: true)
                .Index(t => t.Faculty_Id);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScheduleInfos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubgroupCount = c.Int(nullable: false),
                        HoursPerWeek = c.Int(nullable: false),
                        Lecturer_Id = c.Int(),
                        TutorialType_Id = c.Int(),
                        Department_Id = c.Int(),
                        Tutorial_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lecturers", t => t.Lecturer_Id)
                .ForeignKey("dbo.TutorialTypes", t => t.TutorialType_Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.Tutorials", t => t.Tutorial_Id)
                .Index(t => t.Lecturer_Id)
                .Index(t => t.TutorialType_Id)
                .Index(t => t.Department_Id)
                .Index(t => t.Tutorial_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Code = c.String(),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .Index(t => t.Department_Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        StudentsCount = c.Int(),
                        Course_Id = c.Int(),
                        Speciality_Id = c.Int(),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Specialities", t => t.Speciality_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Parent_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Speciality_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.Lecturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lastname = c.String(),
                        Firstname = c.String(),
                        Middlename = c.String(),
                        Contacts = c.String(),
                        Department_Id = c.Int(),
                        Rank_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ranks", t => t.Rank_Id, cascadeDelete: true)
                .Index(t => t.Department_Id)
                .Index(t => t.Rank_Id);
            
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Auditoriums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Name = c.String(),
                        Capacity = c.Int(nullable: false),
                        Info = c.String(),
                        Building_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.Building_Id, cascadeDelete: true)
                .Index(t => t.Building_Id);
            
            CreateTable(
                "dbo.TutorialTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ShortName = c.String(),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tutorials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.Int(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        Auditorium_Id = c.Int(),
                        Period_Id = c.Int(),
                        ScheduleInfo_Id = c.Int(),
                        WeekType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auditoriums", t => t.Auditorium_Id, cascadeDelete: true)
                .ForeignKey("dbo.Times", t => t.Period_Id, cascadeDelete: true)
                .ForeignKey("dbo.ScheduleInfos", t => t.ScheduleInfo_Id, cascadeDelete: true)
                .ForeignKey("dbo.WeekTypes", t => t.WeekType_Id, cascadeDelete: true)
                .Index(t => t.Auditorium_Id)
                .Index(t => t.Period_Id)
                .Index(t => t.ScheduleInfo_Id)
                .Index(t => t.WeekType_Id);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.Time(nullable: false),
                        End = c.Time(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WeekTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScheduleInfosToFaculties",
                c => new
                    {
                        ScheduleInfo_Id = c.Int(nullable: false),
                        Faculty_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ScheduleInfo_Id, t.Faculty_Id })
                .ForeignKey("dbo.ScheduleInfos", t => t.ScheduleInfo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Faculties", t => t.Faculty_Id, cascadeDelete: true)
                .Index(t => t.ScheduleInfo_Id)
                .Index(t => t.Faculty_Id);
            
            CreateTable(
                "dbo.ScheduleInfosToCourses",
                c => new
                    {
                        ScheduleInfo_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ScheduleInfo_Id, t.Course_Id })
                .ForeignKey("dbo.ScheduleInfos", t => t.ScheduleInfo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.ScheduleInfo_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.ScheduleInfosToSpecialities",
                c => new
                    {
                        ScheduleInfo_Id = c.Int(nullable: false),
                        Speciality_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ScheduleInfo_Id, t.Speciality_Id })
                .ForeignKey("dbo.ScheduleInfos", t => t.ScheduleInfo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Specialities", t => t.Speciality_Id, cascadeDelete: true)
                .Index(t => t.ScheduleInfo_Id)
                .Index(t => t.Speciality_Id);
            
            CreateTable(
                "dbo.ScheduleInfosToGroups",
                c => new
                    {
                        ScheduleInfo_Id = c.Int(nullable: false),
                        Group_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ScheduleInfo_Id, t.Group_Id })
                .ForeignKey("dbo.ScheduleInfos", t => t.ScheduleInfo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .Index(t => t.ScheduleInfo_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.TutorialTypeAuditoriums",
                c => new
                    {
                        TutorialType_Id = c.Int(nullable: false),
                        Auditorium_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TutorialType_Id, t.Auditorium_Id })
                .ForeignKey("dbo.TutorialTypes", t => t.TutorialType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Auditoriums", t => t.Auditorium_Id, cascadeDelete: true)
                .Index(t => t.TutorialType_Id)
                .Index(t => t.Auditorium_Id);
            
            CreateTable(
                "dbo.ScheduleInfosToAuditoriums",
                c => new
                    {
                        ScheduleInfo_Id = c.Int(nullable: false),
                        Auditorium_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ScheduleInfo_Id, t.Auditorium_Id })
                .ForeignKey("dbo.ScheduleInfos", t => t.ScheduleInfo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Auditoriums", t => t.Auditorium_Id, cascadeDelete: true)
                .Index(t => t.ScheduleInfo_Id)
                .Index(t => t.Auditorium_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ScheduleInfosToAuditoriums", new[] { "Auditorium_Id" });
            DropIndex("dbo.ScheduleInfosToAuditoriums", new[] { "ScheduleInfo_Id" });
            DropIndex("dbo.TutorialTypeAuditoriums", new[] { "Auditorium_Id" });
            DropIndex("dbo.TutorialTypeAuditoriums", new[] { "TutorialType_Id" });
            DropIndex("dbo.ScheduleInfosToGroups", new[] { "Group_Id" });
            DropIndex("dbo.ScheduleInfosToGroups", new[] { "ScheduleInfo_Id" });
            DropIndex("dbo.ScheduleInfosToSpecialities", new[] { "Speciality_Id" });
            DropIndex("dbo.ScheduleInfosToSpecialities", new[] { "ScheduleInfo_Id" });
            DropIndex("dbo.ScheduleInfosToCourses", new[] { "Course_Id" });
            DropIndex("dbo.ScheduleInfosToCourses", new[] { "ScheduleInfo_Id" });
            DropIndex("dbo.ScheduleInfosToFaculties", new[] { "Faculty_Id" });
            DropIndex("dbo.ScheduleInfosToFaculties", new[] { "ScheduleInfo_Id" });
            DropIndex("dbo.Schedules", new[] { "WeekType_Id" });
            DropIndex("dbo.Schedules", new[] { "ScheduleInfo_Id" });
            DropIndex("dbo.Schedules", new[] { "Period_Id" });
            DropIndex("dbo.Schedules", new[] { "Auditorium_Id" });
            DropIndex("dbo.Auditoriums", new[] { "Building_Id" });
            DropIndex("dbo.Lecturers", new[] { "Rank_Id" });
            DropIndex("dbo.Lecturers", new[] { "Department_Id" });
            DropIndex("dbo.Groups", new[] { "Parent_Id" });
            DropIndex("dbo.Groups", new[] { "Speciality_Id" });
            DropIndex("dbo.Groups", new[] { "Course_Id" });
            DropIndex("dbo.Specialities", new[] { "Department_Id" });
            DropIndex("dbo.ScheduleInfos", new[] { "Tutorial_Id" });
            DropIndex("dbo.ScheduleInfos", new[] { "Department_Id" });
            DropIndex("dbo.ScheduleInfos", new[] { "TutorialType_Id" });
            DropIndex("dbo.ScheduleInfos", new[] { "Lecturer_Id" });
            DropIndex("dbo.Departments", new[] { "Faculty_Id" });
            DropIndex("dbo.Logs", new[] { "User_Id" });
            DropForeignKey("dbo.ScheduleInfosToAuditoriums", "Auditorium_Id", "dbo.Auditoriums");
            DropForeignKey("dbo.ScheduleInfosToAuditoriums", "ScheduleInfo_Id", "dbo.ScheduleInfos");
            DropForeignKey("dbo.TutorialTypeAuditoriums", "Auditorium_Id", "dbo.Auditoriums");
            DropForeignKey("dbo.TutorialTypeAuditoriums", "TutorialType_Id", "dbo.TutorialTypes");
            DropForeignKey("dbo.ScheduleInfosToGroups", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.ScheduleInfosToGroups", "ScheduleInfo_Id", "dbo.ScheduleInfos");
            DropForeignKey("dbo.ScheduleInfosToSpecialities", "Speciality_Id", "dbo.Specialities");
            DropForeignKey("dbo.ScheduleInfosToSpecialities", "ScheduleInfo_Id", "dbo.ScheduleInfos");
            DropForeignKey("dbo.ScheduleInfosToCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.ScheduleInfosToCourses", "ScheduleInfo_Id", "dbo.ScheduleInfos");
            DropForeignKey("dbo.ScheduleInfosToFaculties", "Faculty_Id", "dbo.Faculties");
            DropForeignKey("dbo.ScheduleInfosToFaculties", "ScheduleInfo_Id", "dbo.ScheduleInfos");
            DropForeignKey("dbo.Schedules", "WeekType_Id", "dbo.WeekTypes");
            DropForeignKey("dbo.Schedules", "ScheduleInfo_Id", "dbo.ScheduleInfos");
            DropForeignKey("dbo.Schedules", "Period_Id", "dbo.Times");
            DropForeignKey("dbo.Schedules", "Auditorium_Id", "dbo.Auditoriums");
            DropForeignKey("dbo.Auditoriums", "Building_Id", "dbo.Buildings");
            DropForeignKey("dbo.Lecturers", "Rank_Id", "dbo.Ranks");
            DropForeignKey("dbo.Lecturers", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Groups", "Parent_Id", "dbo.Groups");
            DropForeignKey("dbo.Groups", "Speciality_Id", "dbo.Specialities");
            DropForeignKey("dbo.Groups", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Specialities", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.ScheduleInfos", "Tutorial_Id", "dbo.Tutorials");
            DropForeignKey("dbo.ScheduleInfos", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.ScheduleInfos", "TutorialType_Id", "dbo.TutorialTypes");
            DropForeignKey("dbo.ScheduleInfos", "Lecturer_Id", "dbo.Lecturers");
            DropForeignKey("dbo.Departments", "Faculty_Id", "dbo.Faculties");
            DropForeignKey("dbo.Logs", "User_Id", "dbo.Users");
            DropTable("dbo.ScheduleInfosToAuditoriums");
            DropTable("dbo.TutorialTypeAuditoriums");
            DropTable("dbo.ScheduleInfosToGroups");
            DropTable("dbo.ScheduleInfosToSpecialities");
            DropTable("dbo.ScheduleInfosToCourses");
            DropTable("dbo.ScheduleInfosToFaculties");
            DropTable("dbo.WeekTypes");
            DropTable("dbo.Times");
            DropTable("dbo.Schedules");
            DropTable("dbo.Tutorials");
            DropTable("dbo.Buildings");
            DropTable("dbo.TutorialTypes");
            DropTable("dbo.Auditoriums");
            DropTable("dbo.Ranks");
            DropTable("dbo.Lecturers");
            DropTable("dbo.Groups");
            DropTable("dbo.Specialities");
            DropTable("dbo.Courses");
            DropTable("dbo.ScheduleInfos");
            DropTable("dbo.Faculties");
            DropTable("dbo.Departments");
            DropTable("dbo.Logs");
            DropTable("dbo.Users");
        }
    }
}
