namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentFeeRecords", "AddedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentFeeRecords", "AddedOn");
        }
    }
}
