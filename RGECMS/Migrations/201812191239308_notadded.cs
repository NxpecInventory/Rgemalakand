namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationMessage = c.String(nullable: false),
                        NotificationDate = c.DateTime(nullable: false),
                        NotificationSpecific = c.String(nullable: false),
                        NotificationAll = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notifications");
        }
    }
}
