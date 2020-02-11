namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedusercoloum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "JoiningDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "JoiningDate");
        }
    }
}
