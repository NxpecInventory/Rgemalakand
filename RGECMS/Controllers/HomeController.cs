using RGECMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RGECMS.Controllers
{
   
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {

            TempData["Totaluser"] =  db.CollegeEmployees.Count();
            TempData["student"] = db.students.Count();
            TempData["Teacher"] = db.Teachers.Count();
                        #region


        
            int JanCount =  db.students.Where(x => x.AddedOn.Month == 1 && x.AddedOn.Year == DateTime.Now.Year).Count();
     
            ViewBag.JanuaryCount = JanCount;
            int FebCount = db.students.Where(x => x.AddedOn.Month == 2 && x.AddedOn.Year == DateTime.Now.Year).Count();
            ViewBag.FebCount = FebCount;
            int MarCount = db.students.Where(x => x.AddedOn.Month == 3 && x.AddedOn.Year == DateTime.Now.Year).Count();
            ViewBag.MarCount = MarCount;
            int AprCount = db.students.Where(x => x.AddedOn.Month == 4 && x.AddedOn.Year == DateTime.Now.Year).Count();
            ViewBag.AprCount = AprCount;
            int MayCount = db.students.Where(x => x.AddedOn.Month == 5 && x.AddedOn.Year == DateTime.Now.Year).Count();
            ViewBag.MayCount = MayCount;
            int JunCount = db.students.Where(x => x.AddedOn.Month == 6 && x.AddedOn.Year == DateTime.Now.Year).Count();
            ViewBag.JunCount = JunCount;
            int JulCount = db.students.Where(x => x.AddedOn.Month == 7 && x.AddedOn.Year == DateTime.Now.Year).Count();
            ViewBag.JulCount = JulCount;
            int AugCount = db.students.Where(x => x.AddedOn.Month == 8 && x.AddedOn.Year == DateTime.Now.Year).Count();
            ViewBag.AugCount = AugCount;
            int SepCount = db.students.Where(x => x.AddedOn.Month == 9 && x.AddedOn.Year == DateTime.Now.Year).Count();
            ViewBag.SepCount = SepCount;
            int OctCount = db.students.Where(x => x.AddedOn.Month == 10 && x.AddedOn.Year == DateTime.Now.Year).Count();
            ViewBag.OctCount = OctCount;
            int NovCount = db.students.Where(x => x.AddedOn.Month == 11 && x.AddedOn.Year == DateTime.Now.Year).Count();
            ViewBag.NovCount = NovCount;
            int DecCount = db.students.Where(x => x.AddedOn.Month == 12 && x.AddedOn.Year == DateTime.Now.Year).Count();
            ViewBag.DecCount = DecCount;



            #endregion

                        #region
            //var studentFeeRecords = db.StudentFeeRecords.Where(x => /*x.AddedOn.Month == DateTime.Now.Year &&*/ x.Payingstatus == "Paid").Count();
            //ViewBag.feePaid = studentFeeRecords;
            //var Paidnot = db.StudentFeeRecords.Where(x => /*x.AddedOn.Month == DateTime.Now.Year &&*/ x.Payingstatus == "").Count();
            //ViewBag.notPaid = Paidnot;
            int JanCountes = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 1 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();

            ViewBag.JanuaryCountes = JanCountes;
            int FebCountes = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 2 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.FebCountes = FebCountes;
            int MarCountes = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 3 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.MarCountes = MarCountes;
            int AprCountes = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 4 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.AprCountes = AprCountes;
            int MayCountes = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 5 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.MayCountes = MayCountes;
            int JunCountes = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 6 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.JunCountes = JunCountes;
            int JulCountes = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 7 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.JulCountes = JulCountes;
            int AugCountes = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 8 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.AugCountes = AugCountes;

            int SepCountes = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 9 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.SepCountes = SepCountes;
            int OctCountes = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 10 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.OctCountes = OctCountes;
            int NovCountes = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 11 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.NovCountes = NovCountes;
            int DecCountes = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 12 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.DecCountes = DecCountes;
            ///////////////////////////////Unpaid Student Fee
            int JanCounts = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 1 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();

            ViewBag.JanuaryCounts = JanCounts;
            int FebCounts = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 2 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.FebCounts = FebCounts;
            int MarCounts = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 3 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.MarCounts = MarCounts;
            int AprCounts = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 4 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.AprCounts = AprCounts;
            int MayCounts = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 5 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.MayCounts = MayCounts;
            int JunCounts = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 6 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.JunCounts = JunCounts;
            int JulCounts = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 7 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.JulCounts = JulCounts;
            int AugCounts = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 8 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.AugCounts = AugCounts;

            int SepCounts = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 9 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.SepCounts = SepCounts;
            int OctCounts = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 10 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.OctCounts = OctCounts;
            int NovCounts = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 11 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.NovCounts = NovCounts;
            int DecCounts = db.StudentFeeRecords.Where(x => x.AddedOn.Month == 12 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.DecCounts = DecCounts;
            #endregion
            #region Teacher

            int JanCountss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 1 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();

            ViewBag.JanuaryCountss = JanCountss;

            int FebCountss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 2 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.FebCountss = FebCountss;
            int MarCountss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 3 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.MarCountss = MarCountss;
            int AprCountss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 4 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.AprCountss = AprCountss;
            int MayCountss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 5 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.MayCountss = MayCountss;
            int JunCountss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 6 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.JunCountss = JunCountss;
            int JulCountss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 7 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.JulCountss = JulCountss;
            int AugCountss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 8 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.AugCountss = AugCountss;

            int SepCountss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 9 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.SepCountss = SepCountss;
            int OctCountss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 10 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.OctCountss = OctCountss;
            int NovCountss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 11 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.NovCountss = NovCountss;
            int DecCountss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 12 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.DecCountss = DecCountss;

            /////////////////////////////////////////Unpaid///////////////////////
            int JanCountsss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 1 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();

            ViewBag.JanuaryCountsss = JanCountsss;

            int FebCountsss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 2 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.FebCountsss = FebCountsss;
            int MarCountsss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 3 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.MarCountsss = MarCountsss;
            int AprCountsss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 4 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.AprCountsss = AprCountsss;
            int MayCountsss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 5 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.MayCountsss = MayCountsss;
            int JunCountsss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 6 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.JunCountsss = JunCountsss;
            int JulCountsss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 7 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.JulCountsss = JulCountsss;
            int AugCountsss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 8 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.AugCountsss = AugCountsss;

            int SepCountsss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 9 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.SepCountsss = SepCountsss;
            int OctCountsss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 10 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.OctCountsss = OctCountsss;
            int NovCountsss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 11 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.NovCountsss = NovCountsss;
            int DecCountsss = db.TeacherSalaryRecords.Where(x => x.AddedOn.Month == 12 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.DecCountsss = DecCountsss;
            #endregion
            #region Employee salary
            int JanCountsse = db.EmployeeSalary.Where(x => x.AddedOn.Month == 1 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();

            ViewBag.JanuaryCountsse = JanCountsse;

            int FebCountsse = db.EmployeeSalary.Where(x => x.AddedOn.Month == 2 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.FebCountsse = FebCountsse;
            int MarCountsse = db.EmployeeSalary.Where(x => x.AddedOn.Month == 3 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.MarCountsse = MarCountsse;
            int AprCountsse = db.EmployeeSalary.Where(x => x.AddedOn.Month == 4 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.AprCountsse = AprCountsse;
            int MayCountsse = db.EmployeeSalary.Where(x => x.AddedOn.Month == 5 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.MayCountsse = MayCountsse;
            int JunCountsse = db.EmployeeSalary.Where(x => x.AddedOn.Month == 6 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.JunCountsse = JunCountsse;
            int JulCountsse = db.EmployeeSalary.Where(x => x.AddedOn.Month == 7 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.JulCountsse = JulCountsse;
            int AugCountsse = db.EmployeeSalary.Where(x => x.AddedOn.Month == 8 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.AugCountsse = AugCountsse;

            int SepCountsse = db.EmployeeSalary.Where(x => x.AddedOn.Month == 9 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.SepCountsse = SepCountsse;
            int OctCountsse = db.EmployeeSalary.Where(x => x.AddedOn.Month == 10 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.OctCountsse = OctCountsse;
            int NovCountsse = db.EmployeeSalary.Where(x => x.AddedOn.Month == 11 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.NovCountsse = NovCountsse;
            int DecCountsse = db.EmployeeSalary.Where(x => x.AddedOn.Month == 12 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "Paid").Count();
            ViewBag.DecCountsse = DecCountsse;

            /////////////////////////////////////////Unpaid///////////////////////
            int JanCountsssee = db.EmployeeSalary.Where(x => x.AddedOn.Month == 1 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();

            ViewBag.JanuaryCountsssee = JanCountsssee;

            int FebCountsssee = db.EmployeeSalary.Where(x => x.AddedOn.Month == 2 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.FebCountsssee = FebCountsssee;
            int MarCountsssee = db.EmployeeSalary.Where(x => x.AddedOn.Month == 3 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.MarCountsssee = MarCountsssee;
            int AprCountsssee = db.EmployeeSalary.Where(x => x.AddedOn.Month == 4 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.AprCountsssee = AprCountsssee;
            int MayCountsssee = db.EmployeeSalary.Where(x => x.AddedOn.Month == 5 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.MayCountsssee = MayCountsssee;
            int JunCountsssee = db.EmployeeSalary.Where(x => x.AddedOn.Month == 6 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.JunCountsssee = JunCountsssee;
            int JulCountsssee = db.EmployeeSalary.Where(x => x.AddedOn.Month == 7 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.JulCountsssee = JulCountsssee;
            int AugCountsssee = db.EmployeeSalary.Where(x => x.AddedOn.Month == 8 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.AugCountsssee = AugCountsssee;

            int SepCountsssee = db.EmployeeSalary.Where(x => x.AddedOn.Month == 9 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.SepCountsssee = SepCountsssee;
            int OctCountsssee = db.EmployeeSalary.Where(x => x.AddedOn.Month == 10 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.OctCountsssee = OctCountsssee;
            int NovCountsssee = db.EmployeeSalary.Where(x => x.AddedOn.Month == 11 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.NovCountsssee = NovCountsssee;
            int DecCountsssee = db.EmployeeSalary.Where(x => x.AddedOn.Month == 12 && x.AddedOn.Year == DateTime.Now.Year && x.Remarks == "UnPaid").Count();
            ViewBag.DecCountsssee = DecCountsssee;
            #endregion

            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult EmployeeHome()
        {
            return View();
        }
      
        public ActionResult Accounts()
        {
            return View();
        }
        public ActionResult CourseHome()
        {
            return View();
        }
        public ActionResult AttendanceHome()
        {
            return View();
        }


    }
}