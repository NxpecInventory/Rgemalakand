namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class printnew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttendanceRecordsdatas", "PrintBinary", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AttendanceRecordsdatas", "PrintBinary");
        }
    }
}
