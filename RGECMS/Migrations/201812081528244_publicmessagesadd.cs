namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publicmessagesadd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Publicmessages", "phoneno", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publicmessages", "phoneno", c => c.Int(nullable: false));
        }
    }
}
