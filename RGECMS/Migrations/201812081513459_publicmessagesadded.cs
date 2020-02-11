namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publicmessagesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publicmessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        phoneno = c.Int(nullable: false),
                        Message = c.String(nullable: false, maxLength: 250),
                        MessageDate = c.DateTime(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Publicmessages");
        }
    }
}
