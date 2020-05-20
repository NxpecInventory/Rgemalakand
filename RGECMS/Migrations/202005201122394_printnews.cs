namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class printnews : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AttendanceRecordsdatas", "PrintBinary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AttendanceRecordsdatas", "PrintBinary", c => c.Binary());
        }
    }
}
