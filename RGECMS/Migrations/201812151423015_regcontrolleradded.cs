namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regcontrolleradded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.regclosingcats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegOptions = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registrationcontrollings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Updationdate = c.DateTime(nullable: false),
                        regclosingid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.regclosingcats", t => t.regclosingid, cascadeDelete: true)
                .Index(t => t.regclosingid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrationcontrollings", "regclosingid", "dbo.regclosingcats");
            DropIndex("dbo.Registrationcontrollings", new[] { "regclosingid" });
            DropTable("dbo.Registrationcontrollings");
            DropTable("dbo.regclosingcats");
        }
    }
}
