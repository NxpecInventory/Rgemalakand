namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Studentcoursessystemadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentClassAssigningSystems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Studentid = c.Int(nullable: false),
                        StudentName = c.String(),
                        year = c.Int(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.StudentCourseRegistrationHistories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Regid = c.Int(nullable: false),
                        Studentid = c.Int(nullable: false),
                        StudentName = c.String(),
                        year = c.Int(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.StudentCoursesBuckets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Regid = c.Int(nullable: false),
                        Studentid = c.Int(nullable: false),
                        StudentName = c.String(),
                        year = c.Int(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCoursesBuckets", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.StudentClassAssigningSystems", "ProgramId", "dbo.Programs");
            DropIndex("dbo.StudentCoursesBuckets", new[] { "ProgramId" });
            DropIndex("dbo.StudentClassAssigningSystems", new[] { "ProgramId" });
            DropTable("dbo.StudentCoursesBuckets");
            DropTable("dbo.StudentCourseRegistrationHistories");
            DropTable("dbo.StudentClassAssigningSystems");
        }
    }
}
