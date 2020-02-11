namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finemodeladdedupdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Finerecords", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Finerecords", "Year", c => c.DateTime(nullable: false));
        }
    }
}
