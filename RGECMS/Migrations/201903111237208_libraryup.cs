namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class libraryup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LibararyBooks", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.LibararyBooks", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.LibararyBooks", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LibararyBooks", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LibararyBooks", "Year", c => c.DateTime(nullable: false));
            DropColumn("dbo.LibararyBooks", "AddedDate");
            DropColumn("dbo.LibararyBooks", "Price");
            DropColumn("dbo.LibararyBooks", "Quantity");
        }
    }
}
