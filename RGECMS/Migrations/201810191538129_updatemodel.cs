namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendanceRecordsdatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        studentid = c.Int(nullable: false),
                        name = c.String(nullable: false),
                        classname = c.String(nullable: false),
                        dataofattendance = c.DateTime(nullable: false),
                        status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "AttendanceRecords_Id", c => c.Int());
            CreateIndex("dbo.Students", "AttendanceRecords_Id");
            AddForeignKey("dbo.Students", "AttendanceRecords_Id", "dbo.AttendanceRecords", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "AttendanceRecords_Id", "dbo.AttendanceRecords");
            DropIndex("dbo.Students", new[] { "AttendanceRecords_Id" });
            DropColumn("dbo.Students", "AttendanceRecords_Id");
            DropTable("dbo.AttendanceRecordsdatas");
        }
    }
}
