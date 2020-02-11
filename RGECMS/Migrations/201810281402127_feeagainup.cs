namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feeagainup : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentFeeRecords", "Name", c => c.String());
            AlterColumn("dbo.StudentFeeRecords", "FatherName", c => c.String());
            AlterColumn("dbo.StudentFeeRecords", "SemesterClass", c => c.String());
            AlterColumn("dbo.StudentFeeRecords", "Remarks", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentFeeRecords", "Remarks", c => c.String());
            AlterColumn("dbo.StudentFeeRecords", "SemesterClass", c => c.String(nullable: false));
            AlterColumn("dbo.StudentFeeRecords", "FatherName", c => c.String(nullable: false));
            AlterColumn("dbo.StudentFeeRecords", "Name", c => c.String(nullable: false));
        }
    }
}
