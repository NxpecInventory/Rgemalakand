namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teachercouseregandrecordadded3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TeacherclassAssignings", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TeacherclassAssignings", "Name", c => c.String(nullable: false));
        }
    }
}
