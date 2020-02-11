namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userup : DbMigration
    {
        public override void Up()
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
                        RolesName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
           
            
        }
        
        public override void Down()
        {
          
            DropTable("dbo.Users");
           
     
        }
    }
}
