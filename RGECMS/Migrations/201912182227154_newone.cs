namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LibarayIssuedBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(),
                        BookId = c.Int(nullable: false),
                        AssignedBy = c.String(),
                        AssignedDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        StudedRegId = c.Int(nullable: false),
                        StudentName = c.String(),
                        StudentDepartment = c.String(),
                        StudentClass = c.String(),
                        Comments = c.String(),
                        fineComment = c.String(),
                        ReceivedStatus = c.String(),
                        Receiveddate = c.DateTime(nullable: false),
                        fineslipid = c.String(),
                        finestatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LibarayIssuedBooks");
        }
    }
}
