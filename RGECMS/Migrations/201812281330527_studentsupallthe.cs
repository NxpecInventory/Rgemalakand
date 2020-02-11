namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentsupallthe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "ClassId" });
            AddColumn("dbo.Students", "ProgramId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "CurrentSemclass", c => c.String());
            CreateIndex("dbo.Students", "ProgramId");
            AddForeignKey("dbo.Students", "ProgramId", "dbo.Programs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ProgramId", "dbo.Programs");
            DropIndex("dbo.Students", new[] { "ProgramId" });
            DropColumn("dbo.Students", "CurrentSemclass");
            DropColumn("dbo.Students", "ProgramId");
            CreateIndex("dbo.Students", "ClassId");
            AddForeignKey("dbo.Students", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
        }
    }
}
