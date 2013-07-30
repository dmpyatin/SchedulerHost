namespace Timetable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFacultyAndRemoveDepartmentRefFromSpeciality : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Specialities", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Specialities", new[] { "Department_Id" });
            AddColumn("dbo.Specialities", "Faculty_Id", c => c.Int());
            AddForeignKey("dbo.Specialities", "Faculty_Id", "dbo.Faculties", "Id");
            CreateIndex("dbo.Specialities", "Faculty_Id");
            DropColumn("dbo.Specialities", "Department_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Specialities", "Department_Id", c => c.Int());
            DropIndex("dbo.Specialities", new[] { "Faculty_Id" });
            DropForeignKey("dbo.Specialities", "Faculty_Id", "dbo.Faculties");
            DropColumn("dbo.Specialities", "Faculty_Id");
            CreateIndex("dbo.Specialities", "Department_Id");
            AddForeignKey("dbo.Specialities", "Department_Id", "dbo.Departments", "Id");
        }
    }
}
