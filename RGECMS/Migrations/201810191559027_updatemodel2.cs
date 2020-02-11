namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AttendanceRecordsdatas", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.AttendanceRecordsdatas", "StatusId");
            AddForeignKey("dbo.AttendanceRecordsdatas", "StatusId", "dbo.Attendanceoptions", "Id", cascadeDelete: true);
            DropColumn("dbo.AttendanceRecordsdatas", "status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AttendanceRecordsdatas", "status", c => c.String(nullable: false));
            DropForeignKey("dbo.AttendanceRecordsdatas", "StatusId", "dbo.Attendanceoptions");
            DropIndex("dbo.AttendanceRecordsdatas", new[] { "StatusId" });
            DropColumn("dbo.AttendanceRecordsdatas", "StatusId");
        }
    }
}
