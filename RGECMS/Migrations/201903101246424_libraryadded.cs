namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class libraryadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LibararyBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        PublisherPlace = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        Program = c.String(nullable: false),
                        Year = c.DateTime(nullable: false),
                        Pages = c.Int(nullable: false),
                        CallNo = c.String(nullable: false),
                        EditionVolume = c.String(),
                        Shelf = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LibararyDepCats", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.LibararyDepCats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LibarayShelfCats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShelfName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LibararyBooks", "DepartmentId", "dbo.LibararyDepCats");
            DropIndex("dbo.LibararyBooks", new[] { "DepartmentId" });
            DropTable("dbo.LibarayShelfCats");
            DropTable("dbo.LibararyDepCats");
            DropTable("dbo.LibararyBooks");
        }
    }
}
