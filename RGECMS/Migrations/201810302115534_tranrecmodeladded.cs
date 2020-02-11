namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tranrecmodeladded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.transactionrecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionType = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                        TransactionYear = c.Int(nullable: false),
                        TransactionAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.transactionrecords");
        }
    }
}
