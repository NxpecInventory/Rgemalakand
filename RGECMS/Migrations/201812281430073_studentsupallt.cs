namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentsupallt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Status", c => c.String(nullable: false));
        }
    }
}
