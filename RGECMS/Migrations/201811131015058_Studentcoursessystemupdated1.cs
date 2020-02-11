namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Studentcoursessystemupdated1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentCoursesBuckets", "ProgramId", "dbo.Programs");
            DropIndex("dbo.StudentCoursesBuckets", new[] { "ProgramId" });
            AlterColumn("dbo.StudentCoursesBuckets", "StudentName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentCoursesBuckets", "StudentName", c => c.String());
            CreateIndex("dbo.StudentCoursesBuckets", "ProgramId");
            AddForeignKey("dbo.StudentCoursesBuckets", "ProgramId", "dbo.Programs", "Id", cascadeDelete: true);
        }
    }
}
