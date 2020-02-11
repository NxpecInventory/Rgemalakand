namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userimproved : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RegistrationNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "RegistrationNo");
        }
    }
}
