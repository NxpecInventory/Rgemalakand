using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RGECMS.Models;
using PagedList;

namespace RGECMS.Controllers
{
    public class EmployeeSalariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployeeSalaries
        public ActionResult Index(string search, int? page)
        {
            var employeeSalary = db.EmployeeSalary.Include(e => e.CollegeEmployees).ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                employeeSalary = employeeSalary.Where(m => m.Id == convertsearch).ToList();
                TempData["Totaluser"] = employeeSalary.Count();
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                TempData["Totaluser"] = employeeSalary.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(employeeSalary.OrderByDescending(m => m.SubmissionDate).ToPagedList(pageNumber, pageSize));
        }

        // GET: EmployeeSalaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalary employeeSalary = db.EmployeeSalary.Find(id);
            if (employeeSalary == null)
            {
                return HttpNotFound();
            }
            return View(employeeSalary);
        }

        // GET: EmployeeSalaries/Create
        public ActionResult Create()
        {
           
            ViewBag.EmployeeId = db.CollegeEmployees.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Id.ToString() })
.ToList();
            var view = new EmployeeSalary
            {
                Year = System.DateTime.Now.Year,
                SubmissionDate = DateTime.Now.Date,
                Remarks = " Full Salary Paid",
                PaymentMethod = "Cash"
            };
            return View();
        }

        // POST: EmployeeSalaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeSalary EmployeeSalary)
        {
            if (ModelState.IsValid)
            {
                EmployeeSalary.GrossTotalAmount = EmployeeSalary.PayingAmount + EmployeeSalary.OverTime;
                EmployeeSalary.Name = (from alias in db.CollegeEmployees where alias.Id == EmployeeSalary.EmployeeId select alias.EmployeeName).FirstOrDefault();
                EmployeeSalary.FatherName = (from alias in db.CollegeEmployees where alias.Id == EmployeeSalary.EmployeeId select alias.FatherName).FirstOrDefault();
                EmployeeSalary.Recievingstatus = "Salary Recieved";
                //int depid = (from alias in db.CollegeEmployees where alias.Id == EmployeeSalary.EmployeeId select alias.DesignationId).FirstOrDefault();
                //EmployeeSalary. = (from alias in db.employeeDesignationCategory where alias.Id == depid select alias.DesignationName).FirstOrDefault();
                if (EmployeeSalary.checkNo == null)
                {
                    EmployeeSalary.checkNo = "N/A";
                }
                if (EmployeeSalary.Remarks == null)
                {
                    EmployeeSalary.Remarks = "N/A";
                }
                db.EmployeeSalary.Add(EmployeeSalary);
                db.SaveChanges();
                db.Entry(EmployeeSalary).GetDatabaseValues();
                int salaryrecid = EmployeeSalary.Id;
                TempData["salid"] = salaryrecid;
                //here inserting expense out come transaction records 
                ExpenseOutgoingRecords expensetransection = new ExpenseOutgoingRecords();
                expensetransection.RecordId = salaryrecid;
                expensetransection.Personid = EmployeeSalary.EmployeeId;
                expensetransection.PersonName = EmployeeSalary.Name;
                expensetransection.TransactionType = "Employee Salary";
                expensetransection.TransactionDate = EmployeeSalary.SubmissionDate;
                expensetransection.TransactionYear = EmployeeSalary.Year;
                expensetransection.TransactionAmount = EmployeeSalary.GrossTotalAmount;
                db.ExpenseOutgoingRecords.Add(expensetransection);
                db.SaveChanges();
                return RedirectToAction("EmployeeSalarySlip");
            }

            ViewBag.EmployeeId = new SelectList(db.CollegeEmployees, "Id", "EmployeeName", EmployeeSalary.EmployeeId);
            return View(EmployeeSalary);
        }
        public ActionResult EmployeeSalarySlip()
        {
            int id = Convert.ToInt32(TempData["salid"]);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           EmployeeSalary employeesalary = db.EmployeeSalary.Find(Convert.ToInt32(id));
            if (employeesalary == null)
            {
                return HttpNotFound();
            }
          int empid = (from alias in db.CollegeEmployees where alias.Id==employeesalary.EmployeeId select alias.DesignationId).FirstOrDefault();
       var desgname = (from alias in db.employeeDesignationCategory where alias.Id==empid select alias.DesignationName).FirstOrDefault();
            TempData["Empdes"] = desgname;
            return View(employeesalary);

        }
        // GET: EmployeeSalaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalary employeeSalary = db.EmployeeSalary.Find(id);
            if (employeeSalary == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.CollegeEmployees, "Id", "EmployeeName", employeeSalary.EmployeeId);
            return View(employeeSalary);
        }

        // POST: EmployeeSalaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FatherName,SubmissionDate,PayingAmount,OverTime,PaymentMethod,checkNo,GrossTotalAmount,Recievingstatus,Year,Remarks,EmployeeId")] EmployeeSalary employeeSalary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeSalary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.CollegeEmployees, "Id", "EmployeeName", employeeSalary.EmployeeId);
            return View(employeeSalary);
        }

        // GET: EmployeeSalaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalary employeeSalary = db.EmployeeSalary.Find(id);
            if (employeeSalary == null)
            {
                return HttpNotFound();
            }
            return View(employeeSalary);
        }

        // POST: EmployeeSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeSalary employeeSalary = db.EmployeeSalary.Find(id);
            db.EmployeeSalary.Remove(employeeSalary);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
