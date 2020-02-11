namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sturegupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentClassAssigningSystems", "ClassName", c => c.String());
            AddColumn("dbo.StudentClassAssigningSystems", "ProgramName", c => c.String());
            AddColumn("dbo.StudentCourseRegistrationHistories", "ClassName", c => c.String());
            AddColumn("dbo.StudentCourseRegistrationHistories", "ProgramName", c => c.String());
            AddColumn("dbo.StudentCoursesBuckets", "ClassName", c => c.String());
            AddColumn("dbo.StudentCoursesBuckets", "ProgramName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentCoursesBuckets", "ProgramName");
            DropColumn("dbo.StudentCoursesBuckets", "ClassName");
            DropColumn("dbo.StudentCourseRegistrationHistories", "ProgramName");
            DropColumn("dbo.StudentCourseRegistrationHistories", "ClassName");
            DropColumn("dbo.StudentClassAssigningSystems", "ProgramName");
            DropColumn("dbo.StudentClassAssigningSystems", "ClassName");
        }
    }
}
