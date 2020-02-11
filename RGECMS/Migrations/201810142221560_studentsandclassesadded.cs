namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentsandclassesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false),
                        ProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ContactInfo = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        AddmissionDate = c.DateTime(nullable: false),
                        StudentImage = c.Binary(nullable: false, storeType: "image"),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "ProgramId", "dbo.Programs");
            DropIndex("dbo.Students", new[] { "ClassId" });
            DropIndex("dbo.Classes", new[] { "ProgramId" });
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
        }
    }
}
