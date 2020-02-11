namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expenseandexpensecatadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.collegeExpenseCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Categories = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExpensesRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecieverName = c.String(nullable: false),
                        PayingDate = c.DateTime(nullable: false),
                        ItemQuantity = c.Int(nullable: false),
                        ItemName = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        TransactionYear = c.Int(nullable: false),
                        PaidAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.collegeExpenseCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpensesRecords", "CategoryId", "dbo.collegeExpenseCategories");
            DropIndex("dbo.ExpensesRecords", new[] { "CategoryId" });
            DropTable("dbo.ExpensesRecords");
            DropTable("dbo.collegeExpenseCategories");
        }
    }
}
