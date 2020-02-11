namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentsupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "GuardianName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "GuardianName");
        }
    }
}
