namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeacherSalaryRecords", "AddedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TeacherSalaryRecords", "Remarks", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TeacherSalaryRecords", "Remarks", c => c.String());
            DropColumn("dbo.TeacherSalaryRecords", "AddedOn");
        }
    }
}
