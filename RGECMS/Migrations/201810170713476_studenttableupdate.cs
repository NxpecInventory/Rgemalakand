namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studenttableupdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "StudentImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "StudentImage", c => c.Binary(nullable: false, storeType: "image"));
        }
    }
}
