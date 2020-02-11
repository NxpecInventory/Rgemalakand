using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RGECMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int RegistrationNo { get; set; }
        public string RoleName { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here0
            userIdentity.AddClaim(new Claim("RegistrationNo", this.RegistrationNo.ToString()));
            userIdentity.AddClaim(new Claim("RoleName", this.RoleName));
            return userIdentity;
        }

    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole():base()
        {

        }
        public ApplicationRole(string roleName) : base(roleName) { }
  

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("RGECMSCONTEXT", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<RGECMS.Models.ApplicationRole> IdentityRoles { get; set; }
        public DbSet<RGECMS.Models.Programs> programs { get; set; }
        public DbSet<RGECMS.Models.Classes> classes { get; set; }
        public DbSet<RGECMS.Models.Subjects> subject { get; set; }
        public DbSet<RGECMS.Models.Students> students { get; set; }
        public DbSet<RGECMS.Models.Attendanceoptions> options { get; set; }
        public DbSet<RGECMS.Models.AttendanceRecordsdata> attendancerecords { get; set; }
        public DbSet<RGECMS.Models.StudentFeeRecords> StudentFeeRecords { get; set; }
        public DbSet<RGECMS.Models.transactionrecords> transactionecords { get; set; }
        public DbSet<RGECMS.Models.collegeExpenseCategories> collegeExpenseCategories { get; set; }
        public DbSet<RGECMS.Models.ExpensesRecords> ExpensesRecords { get; set; }
        public DbSet<RGECMS.Models.Finerecords> Finerecords { get; set; }
        public DbSet<RGECMS.Models.teacherdesignationcategory> teacherdesignationcategory { get; set; }
        public DbSet<RGECMS.Models.Teachers> Teachers { get; set; }
        public DbSet<RGECMS.Models.employeeDesignationCategory> employeeDesignationCategory { get; set; }
        public DbSet<RGECMS.Models.CollegeEmployees> CollegeEmployees { get; set; }
        public DbSet<RGECMS.Models.TeacherclassAssigning> TeacherclassAssigning { get; set; }
        public DbSet<RGECMS.Models.TeacherCoursesRecord> TeacherCoursesRecord { get; set; }
        public DbSet<RGECMS.Models.StudentClassAssigningSystem> StudentClassAssigningSystem { get; set; }
        public DbSet<RGECMS.Models.StudentCourseRegistrationHistory> StudentCourseRegistrationHistory { get; set; }
        public DbSet<RGECMS.Models.StudentCoursesBucket> StudentCoursesBucket { get; set; }
        public DbSet<RGECMS.Models.TeacherSalaryRecords> TeacherSalaryRecords { get; set; }
        public DbSet<RGECMS.Models.EmployeeSalary> EmployeeSalary { get; set; }
        public DbSet<RGECMS.Models.ExpenseOutgoingRecords> ExpenseOutgoingRecords { get; set; }
        public DbSet<RGECMS.Models.Publicmessages> Publicmessages { get; set; }
        public DbSet<RGECMS.Models.CollegeFiles> CollegeFiles { get; set; }
        public DbSet<RGECMS.Models.regclosingcat> regclosingcat { get; set; }
        public DbSet<RGECMS.Models.Registrationcontrolling> Registrationcontrolling { get; set; }
        public DbSet<RGECMS.Models.Notification> Notification { get; set; }
        //libaray system integration start
        public DbSet<RGECMS.Models.LibararyDepCat> LibararyDepCat { get; set; }
        public DbSet<RGECMS.Models.LibarayShelfCat> LibarayShelfCat { get; set; }
        public DbSet<RGECMS.Models.LibararyBooks> LibararyBooks { get; set; }
        public DbSet<LibarayIssuedBooks> LibarayIssuedBooks { get; set; }

    }
}