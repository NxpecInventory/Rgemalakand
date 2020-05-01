namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "AddedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "AddedOn");
        }
    }
}
