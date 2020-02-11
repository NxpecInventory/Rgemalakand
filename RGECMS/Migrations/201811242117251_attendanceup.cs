namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attendanceup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttendanceRecordsdatas", "Classname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AttendanceRecordsdatas", "Classname");
        }
    }
}
