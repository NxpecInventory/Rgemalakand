namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updations : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.EmployeeSalaries", name: "TeacherId", newName: "EmployeeId");
            RenameIndex(table: "dbo.EmployeeSalaries", name: "IX_TeacherId", newName: "IX_EmployeeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.EmployeeSalaries", name: "IX_EmployeeId", newName: "IX_TeacherId");
            RenameColumn(table: "dbo.EmployeeSalaries", name: "EmployeeId", newName: "TeacherId");
        }
    }
}
