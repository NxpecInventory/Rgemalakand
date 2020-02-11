namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teachersalaryadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.teacherdesignationcategories", "DepartmentName", c => c.String(nullable: false));
            AddColumn("dbo.TeacherSalaryRecords", "TeacherDepartment", c => c.String());
            AlterColumn("dbo.ExpenseOutgoingRecords", "Personid", c => c.Int(nullable: false));
            DropColumn("dbo.teacherdesignationcategories", "DesignationName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.teacherdesignationcategories", "DesignationName", c => c.String(nullable: false));
            AlterColumn("dbo.ExpenseOutgoingRecords", "Personid", c => c.String(nullable: false));
            DropColumn("dbo.TeacherSalaryRecords", "TeacherDepartment");
            DropColumn("dbo.teacherdesignationcategories", "DepartmentName");
        }
    }
}
