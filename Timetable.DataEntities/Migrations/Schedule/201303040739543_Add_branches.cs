using System.Data.Entity.Migrations;

namespace Timetable.Data.Migrations.Schedule
{
    public partial class Add_branches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActual = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Faculties", "Branch_Id", c => c.Int());
            AddForeignKey("dbo.Faculties", "Branch_Id", "dbo.Branches", "Id");
            CreateIndex("dbo.Faculties", "Branch_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Faculties", new[] { "Branch_Id" });
            DropForeignKey("dbo.Faculties", "Branch_Id", "dbo.Branches");
            DropColumn("dbo.Faculties", "Branch_Id");
            DropTable("dbo.Branches");
        }
    }
}
