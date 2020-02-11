namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountsoutcomeexpenseadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FatherName = c.String(),
                        SubmissionDate = c.DateTime(nullable: false),
                        PayingAmount = c.Int(nullable: false),
                        OverTime = c.Int(nullable: false),
                        PaymentMethod = c.String(nullable: false),
                        checkNo = c.String(),
                        GrossTotalAmount = c.Int(nullable: false),
                        Recievingstatus = c.String(),
                        Year = c.Int(nullable: false),
                        Remarks = c.String(),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CollegeEmployees", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.ExpenseOutgoingRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionType = c.String(nullable: false),
                        RecordId = c.Int(nullable: false),
                        TransactionYear = c.Int(nullable: false),
                        TransactionAmount = c.Int(nullable: false),
                        PersonName = c.String(nullable: false),
                        Personid = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherSalaryRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FatherName = c.String(),
                        SubmissionDate = c.DateTime(nullable: false),
                        PayingAmount = c.Int(nullable: false),
                        OverTime = c.Int(nullable: false),
                        PaymentMethod = c.String(nullable: false),
                        checkNo = c.String(),
                        GrossTotalAmount = c.Int(nullable: false),
                        Recievingstatus = c.String(),
                        Year = c.Int(nullable: false),
                        Remarks = c.String(),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSalaryRecords", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.EmployeeSalaries", "TeacherId", "dbo.CollegeEmployees");
            DropIndex("dbo.TeacherSalaryRecords", new[] { "TeacherId" });
            DropIndex("dbo.EmployeeSalaries", new[] { "TeacherId" });
            DropTable("dbo.TeacherSalaryRecords");
            DropTable("dbo.ExpenseOutgoingRecords");
            DropTable("dbo.EmployeeSalaries");
        }
    }
}
