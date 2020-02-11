namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ContactInfo = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        RolesName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
