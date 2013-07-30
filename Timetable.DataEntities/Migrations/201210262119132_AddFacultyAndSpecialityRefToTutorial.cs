namespace Timetable.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFacultyAndSpecialityRefToTutorial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tutorials", "Faculty_Id", c => c.Int());
            AddColumn("dbo.Tutorials", "Speciality_Id", c => c.Int());
            AddForeignKey("dbo.Tutorials", "Faculty_Id", "dbo.Faculties", "Id");
            AddForeignKey("dbo.Tutorials", "Speciality_Id", "dbo.Specialities", "Id");
            CreateIndex("dbo.Tutorials", "Faculty_Id");
            CreateIndex("dbo.Tutorials", "Speciality_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tutorials", new[] { "Speciality_Id" });
            DropIndex("dbo.Tutorials", new[] { "Faculty_Id" });
            DropForeignKey("dbo.Tutorials", "Speciality_Id", "dbo.Specialities");
            DropForeignKey("dbo.Tutorials", "Faculty_Id", "dbo.Faculties");
            DropColumn("dbo.Tutorials", "Speciality_Id");
            DropColumn("dbo.Tutorials", "Faculty_Id");
        }
    }
}
