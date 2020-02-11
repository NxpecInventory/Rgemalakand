namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedrecatt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AttendanceRecords", "options_Id", "dbo.Attendanceoptions");
            DropForeignKey("dbo.AttendanceRecords", "student_Id", "dbo.Students");
            DropIndex("dbo.AttendanceRecords", new[] { "options_Id" });
            DropIndex("dbo.AttendanceRecords", new[] { "student_Id" });
            DropColumn("dbo.AttendanceRecords", "options_Id");
            DropColumn("dbo.AttendanceRecords", "student_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AttendanceRecords", "student_Id", c => c.Int());
            AddColumn("dbo.AttendanceRecords", "options_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.AttendanceRecords", "student_Id");
            CreateIndex("dbo.AttendanceRecords", "options_Id");
            AddForeignKey("dbo.AttendanceRecords", "student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.AttendanceRecords", "options_Id", "dbo.Attendanceoptions", "Id", cascadeDelete: true);
        }
    }
}
