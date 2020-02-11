namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fileadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollegeFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileDescription = c.String(nullable: false),
                        file = c.Byte(nullable: false),
                        FileCat = c.String(nullable: false),
                        uploderid = c.Int(nullable: false),
                        Uploadername = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CollegeFiles");
        }
    }
}
