namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teachercouseregandrecordadded1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TeacherclassAssignings", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.TeacherCoursesRecords", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TeacherCoursesRecords", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.TeacherclassAssignings", "Name", c => c.Int(nullable: false));
        }
    }
}
