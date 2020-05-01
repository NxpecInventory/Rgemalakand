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
    public class TeacherSalaryRecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeacherSalaryRecords
        public ActionResult Index(string search, int? page)
        {
            var teacherSalaryRecords = db.TeacherSalaryRecords.Include(t => t.Teachers).ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                teacherSalaryRecords = teacherSalaryRecords.Where(m => m.TeacherId== convertsearch).ToList();
                TempData["Totaluser"] = teacherSalaryRecords.Count();
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                TempData["Totaluser"] = teacherSalaryRecords.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);

            return View(teacherSalaryRecords.OrderByDescending(m => m.SubmissionDate).ToPagedList(pageNumber, pageSize));
        }

        // GET: TeacherSalaryRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherSalaryRecords teacherSalaryRecords = db.TeacherSalaryRecords.Find(id);
            if (teacherSalaryRecords == null)
            {
                return HttpNotFound();
            }
            return View(teacherSalaryRecords);
        }

        // GET: TeacherSalaryRecords/Create
        public ActionResult Create()
        {
            ViewBag.TeacherId = db.Teachers.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Id.ToString() })
  .ToList();
            var view = new TeacherSalaryRecords
            {
                Year= System.DateTime.Now.Year,
                SubmissionDate = DateTime.Now.Date,
                Remarks = " Full Salary Paid",
                PaymentMethod = "Cash"
            };
            return View(view);
        }

        // POST: TeacherSalaryRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherSalaryRecords teacherSalaryRecords)
        {
            if (ModelState.IsValid)
            {
                teacherSalaryRecords.GrossTotalAmount = teacherSalaryRecords.PayingAmount + teacherSalaryRecords.OverTime;
                teacherSalaryRecords.Name= (from alias in db.Teachers where alias.Id == teacherSalaryRecords.TeacherId select alias.TeacherName).FirstOrDefault();
                teacherSalaryRecords.FatherName = (from alias in db.Teachers where alias.Id == teacherSalaryRecords.TeacherId select alias.FatherName).FirstOrDefault();
                teacherSalaryRecords.Recievingstatus = "Salary Recieved";
               int depid = (from alias in db.Teachers where alias.Id == teacherSalaryRecords.TeacherId select alias.DesignationId).FirstOrDefault();
                teacherSalaryRecords.TeacherDepartment = (from alias in db.teacherdesignationcategory where alias.Id==depid select alias.DepartmentName).FirstOrDefault();
                if (teacherSalaryRecords.checkNo == null)
                {
                    teacherSalaryRecords.checkNo = "N/A";
                }
                if (teacherSalaryRecords.Remarks == null)
                {
                    teacherSalaryRecords.Remarks="N/A";
                }
                teacherSalaryRecords.AddedOn = DateTime.UtcNow.AddHours(5);
                db.TeacherSalaryRecords.Add(teacherSalaryRecords);
                db.SaveChanges();
                db.Entry(teacherSalaryRecords).GetDatabaseValues();
                int salaryrecid = teacherSalaryRecords.Id;
                TempData["salid"] = salaryrecid;
                //here inserting expense out come transaction records 
                ExpenseOutgoingRecords expensetransection = new ExpenseOutgoingRecords();
                expensetransection.RecordId = salaryrecid;
                expensetransection.Personid = teacherSalaryRecords.TeacherId;
                expensetransection.PersonName = teacherSalaryRecords.Name;
                expensetransection.TransactionType = "Teacher Salary";
                expensetransection.TransactionDate = teacherSalaryRecords.SubmissionDate;
                expensetransection.TransactionYear = teacherSalaryRecords.Year;
                expensetransection.TransactionAmount = teacherSalaryRecords.GrossTotalAmount;

                db.ExpenseOutgoingRecords.Add(expensetransection);
                db.SaveChanges();
                return RedirectToAction("PrintSalarySlip");
            }

            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName", teacherSalaryRecords.TeacherId);
            return View(teacherSalaryRecords);
        }
        public ActionResult PrintSalarySlip()
        {
            int id = Convert.ToInt32(TempData["salid"]);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           TeacherSalaryRecords teachersalaryRecords = db.TeacherSalaryRecords.Find(Convert.ToInt32(id));
            if (teachersalaryRecords == null)
            {
                return HttpNotFound();
            }
        
            return View(teachersalaryRecords);
           
        }

        // GET: TeacherSalaryRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherSalaryRecords teacherSalaryRecords = db.TeacherSalaryRecords.Find(id);
            if (teacherSalaryRecords == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName", teacherSalaryRecords.TeacherId);
            return View(teacherSalaryRecords);
        }

        // POST: TeacherSalaryRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FatherName,SubmissionDate,PayingAmount,OverTime,PaymentMethod,checkNo,GrossTotalAmount,Recievingstatus,Year,Remarks,TeacherId")] TeacherSalaryRecords teacherSalaryRecords)
        {
            if (ModelState.IsValid)
            {
                teacherSalaryRecords.GrossTotalAmount = teacherSalaryRecords.PayingAmount + teacherSalaryRecords.OverTime;
                int depid = (from alias in db.Teachers where alias.Id == teacherSalaryRecords.TeacherId select alias.DesignationId).FirstOrDefault();
                teacherSalaryRecords.TeacherDepartment = (from alias in db.teacherdesignationcategory where alias.Id == depid select alias.DepartmentName).FirstOrDefault();
                db.Entry(teacherSalaryRecords).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName", teacherSalaryRecords.TeacherId);
            return View(teacherSalaryRecords);
        }

        // GET: TeacherSalaryRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherSalaryRecords teacherSalaryRecords = db.TeacherSalaryRecords.Find(id);
            if (teacherSalaryRecords == null)
            {
                return HttpNotFound();
            }
            return View(teacherSalaryRecords);
        }

        // POST: TeacherSalaryRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherSalaryRecords teacherSalaryRecords = db.TeacherSalaryRecords.Find(id);
            db.TeacherSalaryRecords.Remove(teacherSalaryRecords);
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
