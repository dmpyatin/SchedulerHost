namespace Timetable.Data.Migrations.Schedule
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_AutoDeleteField_In_Schedules : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "AutoDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "AutoDelete");
        }
    }
}
