namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class collegeemplyee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollegeEmployees", "Uploadimage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CollegeEmployees", "Uploadimage");
        }
    }
}
