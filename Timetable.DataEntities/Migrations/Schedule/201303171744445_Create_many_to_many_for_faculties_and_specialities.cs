using System.Data.Entity.Migrations;

namespace Timetable.Data.Migrations.Schedule
{
    public partial class Create_many_to_many_for_faculties_and_specialities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Specialities", "Faculty_Id", "dbo.Faculties");
            DropIndex("dbo.Specialities", new[] { "Faculty_Id" });
            CreateTable(
                "dbo.FacultiesToSpecialities",
                c => new
                    {
                        Faculty_Id = c.Int(nullable: false),
                        Speciality_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Faculty_Id, t.Speciality_Id })
                .ForeignKey("dbo.Faculties", t => t.Faculty_Id, cascadeDelete: true)
                .ForeignKey("dbo.Specialities", t => t.Speciality_Id, cascadeDelete: true)
                .Index(t => t.Faculty_Id)
                .Index(t => t.Speciality_Id);
            
            DropColumn("dbo.Specialities", "Faculty_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Specialities", "Faculty_Id", c => c.Int());
            DropIndex("dbo.FacultiesToSpecialities", new[] { "Speciality_Id" });
            DropIndex("dbo.FacultiesToSpecialities", new[] { "Faculty_Id" });
            DropForeignKey("dbo.FacultiesToSpecialities", "Speciality_Id", "dbo.Specialities");
            DropForeignKey("dbo.FacultiesToSpecialities", "Faculty_Id", "dbo.Faculties");
            DropTable("dbo.FacultiesToSpecialities");
            CreateIndex("dbo.Specialities", "Faculty_Id");
            AddForeignKey("dbo.Specialities", "Faculty_Id", "dbo.Faculties", "Id");
        }
    }
}
