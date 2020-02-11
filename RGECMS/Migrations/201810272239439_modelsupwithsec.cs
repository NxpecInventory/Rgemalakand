namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelsupwithsec : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentFeeRecords", "SecFee", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentFeeRecords", "SecFee", c => c.String(nullable: false));
        }
    }
}
