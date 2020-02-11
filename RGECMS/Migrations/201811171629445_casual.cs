namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class casual : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttendanceRecordsdatas", "AttendanceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AttendanceRecordsdatas", "AttendanceId");
        }
    }
}
