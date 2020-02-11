namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fileadupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollegeFiles", "filepath", c => c.String(nullable: false));
            AddColumn("dbo.CollegeFiles", "UploadingDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.CollegeFiles", "file");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CollegeFiles", "file", c => c.Byte(nullable: false));
            DropColumn("dbo.CollegeFiles", "UploadingDate");
            DropColumn("dbo.CollegeFiles", "filepath");
        }
    }
}
