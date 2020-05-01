namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "PrintBinary", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "PrintBinary");
        }
    }
}
