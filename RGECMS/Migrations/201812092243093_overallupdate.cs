namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class overallupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeacherclassAssignings", "ClassName", c => c.String());
            AddColumn("dbo.TeacherclassAssignings", "ProgramName", c => c.String());
            AddColumn("dbo.TeacherclassAssignings", "SubjectName", c => c.String());
            AddColumn("dbo.TeacherCoursesRecords", "ClassName", c => c.String());
            AddColumn("dbo.TeacherCoursesRecords", "ProgramName", c => c.String());
            AddColumn("dbo.TeacherCoursesRecords", "SubjectName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeacherCoursesRecords", "SubjectName");
            DropColumn("dbo.TeacherCoursesRecords", "ProgramName");
            DropColumn("dbo.TeacherCoursesRecords", "ClassName");
            DropColumn("dbo.TeacherclassAssignings", "SubjectName");
            DropColumn("dbo.TeacherclassAssignings", "ProgramName");
            DropColumn("dbo.TeacherclassAssignings", "ClassName");
        }
    }
}
