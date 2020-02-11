namespace RGECMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacheremployeeadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollegeEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ContactInfo = c.String(nullable: false),
                        Status = c.String(),
                        JoiningDate = c.DateTime(nullable: false),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.employeeDesignationCategories", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.employeeDesignationCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.teacherdesignationcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ContactInfo = c.String(nullable: false),
                        Status = c.String(),
                        JoiningDate = c.DateTime(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        Specialization = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.teacherdesignationcategories", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.teacherdesignationcategories");
            DropForeignKey("dbo.CollegeEmployees", "DesignationId", "dbo.employeeDesignationCategories");
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.CollegeEmployees", new[] { "DesignationId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.teacherdesignationcategories");
            DropTable("dbo.employeeDesignationCategories");
            DropTable("dbo.CollegeEmployees");
        }
    }
}
