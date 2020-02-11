namespace RGECMS.Migrations
{

    using System.Data.Entity.Migrations;
    
    public partial class finemodeladded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Finerecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SemesterClass = c.String(nullable: false),
                        SubmissionDate = c.DateTime(nullable: false),
                        FineAmount = c.Int(nullable: false),
                        TotalAmount = c.Int(nullable: false),
                        Payingstatus = c.String(nullable: false),
                        Year = c.DateTime(nullable: false),
                        Remarks = c.String(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Finerecords", "StudentId", "dbo.Students");
            DropIndex("dbo.Finerecords", new[] { "StudentId" });
            DropTable("dbo.Finerecords");
        }
    }
}
