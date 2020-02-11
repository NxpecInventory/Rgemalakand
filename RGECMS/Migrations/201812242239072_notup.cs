namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notup : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "NotificationAll", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifications", "NotificationAll", c => c.String(nullable: false));
        }
    }
}
