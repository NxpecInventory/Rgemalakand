namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class students : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Uploadimage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Uploadimage", c => c.String(nullable: false));
        }
    }
}
