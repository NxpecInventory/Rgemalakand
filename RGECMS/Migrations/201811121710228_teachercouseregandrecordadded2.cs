namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teachercouseregandrecordadded2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TeacherclassAssignings", "ProgramId");
            AddForeignKey("dbo.TeacherclassAssignings", "ProgramId", "dbo.Programs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherclassAssignings", "ProgramId", "dbo.Programs");
            DropIndex("dbo.TeacherclassAssignings", new[] { "ProgramId" });
        }
    }
}
