namespace RGECMS.Migrations
{
    using System; 
    using System.Data.Entity.Migrations;
    
    public partial class Attendance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttendanceRecordsdatas", "ClassId", c => c.Int(nullable: false));
            DropColumn("dbo.AttendanceRecordsdatas", "AttendanceId");
            DropColumn("dbo.AttendanceRecordsdatas", "classname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AttendanceRecordsdatas", "classname", c => c.String(nullable: false));
            AddColumn("dbo.AttendanceRecordsdatas", "AttendanceId", c => c.Int(nullable: false));
            DropColumn("dbo.AttendanceRecordsdatas", "ClassId");
        }
    }
}
