namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teachercouseregandrecordadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeacherclassAssignings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Teacherid = c.Int(nullable: false),
                        Name = c.Int(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TeacherCoursesRecords",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Teacherid = c.Int(nullable: false),
                        Name = c.Int(nullable: false),
                        Assignedprocessid = c.Int(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeacherCoursesRecords");
            DropTable("dbo.TeacherclassAssignings");
        }
    }
}
