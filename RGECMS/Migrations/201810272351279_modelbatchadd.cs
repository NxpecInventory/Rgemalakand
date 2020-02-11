namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelbatchadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentFeeRecords", "batch", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentFeeRecords", "batch");
        }
    }
}
