namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attendance1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendanceoptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Options = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AttendanceRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttendanceDate = c.DateTime(nullable: false),
                        ClassId = c.Int(nullable: false),
                        options_Id = c.Int(nullable: false),
                        student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Attendanceoptions", t => t.options_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.student_Id)
                .Index(t => t.ClassId)
                .Index(t => t.options_Id)
                .Index(t => t.student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttendanceRecords", "student_Id", "dbo.Students");
            DropForeignKey("dbo.AttendanceRecords", "options_Id", "dbo.Attendanceoptions");
            DropForeignKey("dbo.AttendanceRecords", "ClassId", "dbo.Classes");
            DropIndex("dbo.AttendanceRecords", new[] { "student_Id" });
            DropIndex("dbo.AttendanceRecords", new[] { "options_Id" });
            DropIndex("dbo.AttendanceRecords", new[] { "ClassId" });
            DropTable("dbo.AttendanceRecords");
            DropTable("dbo.Attendanceoptions");
        }
    }
}
