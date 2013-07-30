namespace Timetable.Data.Migrations.Schedule
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Position_column_to_the_Times_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Times", "Position", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Times", "Position");
        }
    }
}
