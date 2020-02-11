using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RGECMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RGECMS.Controllers
{
    public class EmployeeController : Controller
    {

        // GET: Employee
        private ApplicationDbContext db = new ApplicationDbContext();

        ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext
            ().GetUserManager<ApplicationUserManager>().FindById
            (System.Web.HttpContext.Current.User.Identity.GetUserId());
        //[Authorize]
        public ActionResult EmployeeProfile()
        {
            CollegeEmployees employee = db.CollegeEmployees.Find(user.RegistrationNo);
            if (employee != null)
            { //here problem designation solved 
                var getdesig = (from alias in db.CollegeEmployees where alias.Id == user.RegistrationNo select alias.DesignationId).FirstOrDefault();
                var getname = (from alias in db.employeeDesignationCategory where alias.Id == getdesig select alias.DesignationName).FirstOrDefault();
                TempData["name"] = getname;
                return View(employee);
            }
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult StudentFeesReport()
        {
            return View();
        }

        // GET: Employee/Create
        int checkmonth(string month)
        {
            if (month == "January")
            {
                return 1;
            }
            if (month == "February")
            {
                return 2;
            }
            if (month == "March")
            {
                return 3;
            }
            if (month == "April")
            {
                return 4;
            }
            if (month == "May")
            {
                return 5;
            }
            if (month == "June")
            {
                return 6;
            }
            if (month == "July")
            {
                return 7;
            }
            if (month == "August")
            {
                return 8;
            }
            if (month == "September")
            {
                return 9;
            }
            if (month == "October")
            {
                return 10;
            }
            if (month == "November")
            {
                return 11;
            }
            if (month == "December")
            {
                return 12;
            }
            return 0;
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentFeesReport(ReportViewModel report)
        {
            int totalamount = 0;

            int getmonthint = checkmonth(report.Month);
            if (getmonthint != 0)
            {
                var reportgetamount = (from alias in db.StudentFeeRecords
                                       where alias.SubmissionDate.Month ==
    getmonthint && alias.Year.Year == report.Year
                                       select alias).ToList();

                TempData["Count"] = "Student Fees Report OF Month:" +" "+ report.Month + "And Year:"+" " +" " +report.Year ;
                TempData["Countno"] = reportgetamount.Count();
                foreach (var i in reportgetamount)
                {
                    totalamount = totalamount + i.GrossTotalAmount;
                }
                if (reportgetamount == null || reportgetamount.Count == 0)
                {
                    ModelState.AddModelError("", "The Given Year/ Month Student Fee Record Not Found.");
                    return View (report);
                }

        TempData["TotalAmount"] = totalamount;
                TempData["Getlist"] = reportgetamount;
                return RedirectToAction("ShowFeeReport");
            }
            ModelState.AddModelError("", "Invalid Year OR Month Given Please Give The Valid and Correct Spelling Month And Year.");
   
            return View(report);




        }

      public ActionResult ShowFeeReport()
        {
     var showlist = TempData["Getlist"];
 return View(showlist);
        }

        //here am going to create the employee report pannel
        public ActionResult EmployeeSalaryReport()
        {
            return View();
        }





        // from here the teacher salary reports start
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeSalaryReport(teacherreportviewmodel report)
        {
            int totalamount = 0;

            int getmonthint = checkmonth(report.Month);
            if (getmonthint != 0)
            {
                var reportgetamount = (from alias in db.EmployeeSalary
                                       where alias.SubmissionDate.Month ==getmonthint && alias.Year == report.Year
                                       select alias).ToList();

                TempData["Count"] = "Employee Salary/Pay Report OF Month:" + " " + report.Month + " " + "And Year:" + " " + report.Year;
                TempData["Countno"] = reportgetamount.Count();
                foreach (var i in reportgetamount)
                {
                    totalamount = totalamount + i.GrossTotalAmount;
                }
                if (reportgetamount == null || reportgetamount.Count == 0)
                {
                    ModelState.AddModelError("", "The Given Year/ Month Employee Salarys/Pays Record Not Found.");
                    return View(report);
                }

                TempData["TotalAmount"] = totalamount;
                TempData["liste"] = reportgetamount;
                return RedirectToAction("ShowEmployeeSalaryReport");
            }
            ModelState.AddModelError("", "Invalid Year OR Month Given Please Give The Valid and Correct Spelling Month And Year.");

            return View(report);




        }
        public ActionResult ShowEmployeeSalaryReport()
        {
            var showlist = TempData["liste"];
            return View(showlist);
        }
        //above employee report ends
        // here get input theacher report start
        // POST: Employee/Create
        public ActionResult TeacherSalaryReport()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeacherSalaryReport(teacherreportviewmodel report)
        {
            int totalamount = 0;

            int getmonthint = checkmonth(report.Month);
            if (getmonthint != 0)
            {
                var reportgetamount = (from alias in db.TeacherSalaryRecords
                                       where alias.SubmissionDate.Month ==
    getmonthint && alias.Year == report.Year
                                       select alias).ToList();

                TempData["Count"] = "Teacher Salary/Pay Report OF Month:" + " " + report.Month +" "+ "And Year:" + " " + report.Year;
                TempData["Countno"] = reportgetamount.Count();
                foreach (var i in reportgetamount)
                {
                    totalamount = totalamount + i.GrossTotalAmount;
                }
                if (reportgetamount == null || reportgetamount.Count == 0)
                {
                    ModelState.AddModelError("", "The Given Year/ Month Teacher Salarys/Pays Record Not Found.");
                    return View(report);
                }

                TempData["TotalAmount"] = totalamount;
                TempData["list"] = reportgetamount;
                return RedirectToAction("ShowTeacherSalaryReport");
            }
            ModelState.AddModelError("", "Invalid Year OR Month Given Please Give The Valid and Correct Spelling Month And Year.");

            return View(report);




        }
        public ActionResult ShowTeacherSalaryReport()
        {
            var showlist = TempData["list"];
            return View(showlist);
        }
        //here fine reports start
        public ActionResult FineReport()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FineReport(Studentfinereportviewmodel report)
        {
            int totalamount = 0;

            int getmonthint = checkmonth(report.Month);
            if (getmonthint != 0)
            {
                var reportgetamount = (from alias in db.Finerecords
                                       where alias.SubmissionDate.Month ==
    getmonthint && alias.SubmissionDate.Year == report.Year
                                       select alias).ToList();

                TempData["Count"] = "Student Fine Report OF Month:" + " " + report.Month + " " + "And Year:" + " " + report.Year;
                TempData["Countno"] = reportgetamount.Count();
                foreach (var i in reportgetamount)
                {
                    totalamount = totalamount + i.TotalAmount;
                }
                if (reportgetamount == null || reportgetamount.Count == 0)
                {
                    ModelState.AddModelError("", "The Given Year/ Month Student Fines Record Not Found.");
                    return View(report);
                }

                TempData["TotalAmount"] = totalamount;
                TempData["finelist"] = reportgetamount;
                return RedirectToAction("ShowFinesReport");
            }
            ModelState.AddModelError("", "Invalid Year OR Month Given Please Give The Valid and Correct Spelling Month And Year.");

            return View(report);




        }
        public ActionResult ShowFinesReport()
        {
            var showlist = TempData["finelist"];
            return View(showlist);
        }
        //here
        public ActionResult InventoryExpenseReport()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InventoryExpenseReport(expensereportviewmodel  report)
        {
            int totalamount = 0;

            int getmonthint = checkmonth(report.Month);
            if (getmonthint != 0)
            {
                var reportgetamount = (from alias in db.ExpensesRecords
                                       where alias.PayingDate.Month ==
    getmonthint && alias.TransactionYear == report.Year
                                       select alias).ToList();

                TempData["Count"] = "Inventory Expense Report OF Month:" + " " + report.Month + " " + "And Year:" + " " + report.Year;
                TempData["Countno"] = reportgetamount.Count();
                foreach (var i in reportgetamount)
                {
                    totalamount = totalamount + i.PaidAmount;
                }
                if (reportgetamount == null || reportgetamount.Count == 0)
                {
                    ModelState.AddModelError("", "The Given Year/ Month Inventory Expense Record Not Found.");
                    return View(report);
                }

                TempData["TotalAmount"] = totalamount;
                TempData["list"] = reportgetamount;
                return RedirectToAction("InventoryExpenseslip");
            }
            ModelState.AddModelError("", "Invalid Year OR Month Given Please Give The Valid and Correct Spelling Month And Year.");

            return View(report);




        }

        public ActionResult InventoryExpenseslip()
        {
            var showlist = TempData["list"];
            return View(showlist);
        }
        //here income out come report starts
        public ActionResult IncomeOutcomeReport()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IncomeOutcomeReport(IncomeOutcomeviewmodel report)
        {
            int studentfeestotal = 0;
            int studentfinetotal = 0;

            int getmonthint = checkmonth(report.Month);
            if (getmonthint != 0)
            {
                var reportgetamount = (from alias in db.StudentFeeRecords
                                       where alias.SubmissionDate.Month ==
    getmonthint && alias.Year.Year == report.Year
                                       select alias).ToList();

                TempData["Count"] = "Rahman Group OF Education College Income And OutCome Report OF Month:" + " " + report.Month + " " + "And Year:" + " " + report.Year;
                TempData["NoOfStudents"] = reportgetamount.Count();
                var getfineamount = (from alias in db.Finerecords   ///here getting Fines Record
                                       where alias.SubmissionDate.Month ==
    getmonthint && alias.SubmissionDate.Year == report.Year
                                       select alias).ToList();

                foreach (var i in getfineamount)// here adding and getting fees record 
                {
                    studentfinetotal = studentfinetotal + i.TotalAmount;
                }
                foreach (var i in reportgetamount)// here adding and getting fees record 
                {
                    studentfeestotal = studentfeestotal + i.GrossTotalAmount;
                }

                TempData["TotalFeesAmount"] = studentfeestotal;
                TempData["TotalFineAmount"] = studentfinetotal;
                TempData["Nooffines"] = getfineamount.Count();
                int incometotal = studentfeestotal + studentfinetotal;
                TempData["TotalIncomeAmount"] = studentfeestotal+studentfinetotal;
                //here outcome starts 
                var getteacheramounts = (from alias in db.TeacherSalaryRecords
                                       where alias.SubmissionDate.Month ==
    getmonthint && alias.Year == report.Year
                                       select alias).ToList();// here teacher salary getting
                var getemployeeamounts = (from alias in db.EmployeeSalary
                                         where alias.SubmissionDate.Month ==
      getmonthint && alias.Year == report.Year
                                         select alias).ToList();//here employee salary
                var getExpenseamounts = (from alias in db.ExpensesRecords
                                          where alias.PayingDate.Month ==
       getmonthint && alias.TransactionYear == report.Year
                                          select alias).ToList();//here expense amount
                int expensetotal = 0;
                int employeetotal = 0;
                int teachersalarytotal = 0;
                foreach (var i in getteacheramounts)// here adding teacher salary
                {
                    teachersalarytotal = teachersalarytotal + i.GrossTotalAmount;
                }
                foreach (var i in getemployeeamounts)// here adding Employee salary
                {
                    employeetotal = employeetotal + i.GrossTotalAmount;
                }
                foreach (var i in getExpenseamounts)// here adding teacher salary
                {
                    expensetotal = expensetotal + i.PaidAmount;
                }
            
                TempData["TotalTeacherSalary"] = teachersalarytotal;
                TempData["TotalEmployeeSalary"] = employeetotal;
                TempData["TotalExpense"] = expensetotal;
                TempData["TotalnoofTeacherSalary"] = getteacheramounts.Count();
                TempData["TotalnoofemployeeSalary"] = getemployeeamounts.Count();
                TempData["Totalnoofexpense"] = getExpenseamounts.Count();
                TempData["TotalOutComeAmount"] = expensetotal + employeetotal + teachersalarytotal;
                int outcometotal = expensetotal + employeetotal + teachersalarytotal;
                int overtotal = incometotal - outcometotal;
                TempData["TotalCurrent"] = overtotal;
                if (incometotal==0&&outcometotal==0)
                {
                    ModelState.AddModelError("", "The Given Year/ Month Income and OutGoing Record Not Found.");
                    return View(report);
                }
                return RedirectToAction("IncomeOutcomeReportslip");
            }
            ModelState.AddModelError("", "Invalid Year OR Month Given Please Give The Valid and Correct Spelling Month And Year.");

            return View(report);




        }

        public ActionResult IncomeOutcomeReportslip()
        {
          
            return View();
        }
    }
}
