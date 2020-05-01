using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RGECMS.Models;
using System.Data.Entity.Migrations;
using System.Web.Routing;
using PagedList;

namespace RGECMS.Controllers
{
    public class StudentFeeRecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentFeeRecords
        public ActionResult Index(string search, int? page)
        {
            var studentFeeRecords = db.StudentFeeRecords.Include( s => s.Students).ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                studentFeeRecords = studentFeeRecords.Where(m => m.StudentId == convertsearch).ToList();
                TempData["Totaluser"] = studentFeeRecords.Count();
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                TempData["Totaluser"] = studentFeeRecords.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(studentFeeRecords.OrderByDescending(m => m.SubmissionDate).ToPagedList(pageNumber, pageSize));
        }

        // GET: StudentFeeRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentFeeRecords studentFeeRecords = db.StudentFeeRecords.Find(id);
            if (studentFeeRecords == null)
            {
                return HttpNotFound();
            }
            return View(studentFeeRecords);
        }

        // GET: StudentFeeRecords/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = db.students.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Id.ToString() })
  .ToList();

            var view = new StudentFeeRecords
            {
                batch = System.DateTime.Now.Year,
                SubmissionDate=DateTime.Now.Date,
                Remarks="Paid On Time",
                PaymentMethod="Cash"

                
            };
            return View(view);
        }

        // POST: StudentFeeRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentFeeRecords studentFeeRecords)
        {

            if (ModelState.IsValid){
                studentFeeRecords.GrossTotalAmount = studentFeeRecords.AdmissionFeeTutionFee + studentFeeRecords.SecFee + studentFeeRecords.HostelFee;
                studentFeeRecords.Payingstatus = "Paid";
            
               int classid = (from alias in db.students where alias.Id == studentFeeRecords.StudentId select alias.ClassId).FirstOrDefault();
                studentFeeRecords.SemesterClass= (from alias in db.classes where alias.Id == classid select alias.ClassName).FirstOrDefault();
                studentFeeRecords.batch = DateTime.Now.Year;
                studentFeeRecords.Name = (from alias in db.students where alias.Id == studentFeeRecords.StudentId select alias.StudentName).FirstOrDefault();
                studentFeeRecords.FatherName = (from alias in db.students where alias.Id == studentFeeRecords.StudentId select alias.GuardianName).FirstOrDefault();
                studentFeeRecords.Year = DateTime.Now;
                StudentFeeRecords finalslip = new StudentFeeRecords();
                transactionrecords transaction = new transactionrecords();

                finalslip.Id = studentFeeRecords.Id;
                finalslip.FatherName = studentFeeRecords.FatherName;
                finalslip.GrossTotalAmount = studentFeeRecords.GrossTotalAmount;
                finalslip.Payingstatus = studentFeeRecords.Payingstatus;
                finalslip.PaymentMethod = studentFeeRecords.PaymentMethod;
                finalslip.HostelFee = studentFeeRecords.HostelFee;
                finalslip.SecFee = studentFeeRecords.SecFee;
                finalslip.AdmissionFeeTutionFee = studentFeeRecords.AdmissionFeeTutionFee;
                finalslip.SubmissionDate = studentFeeRecords.SubmissionDate;
                finalslip.Remarks = studentFeeRecords.Remarks;
                finalslip.Year = studentFeeRecords.Year;
                finalslip.batch = studentFeeRecords.batch;
                //here normal record ends and students retrieving record start
                
                finalslip.SemesterClass = studentFeeRecords.SemesterClass;
                
                finalslip.Name = studentFeeRecords.Name;
 
                finalslip.FatherName = studentFeeRecords.FatherName;

                finalslip.StudentId = studentFeeRecords.StudentId;
                //here insterting transaction record
                transaction.PersonId = finalslip.StudentId;
                transaction.TransactionAmount = finalslip.GrossTotalAmount;
                transaction.TransactionDate = finalslip.SubmissionDate;
                transaction.TransactionYear = finalslip.batch;
                transaction.TransactionType = "Fees";

                finalslip.AddedOn = DateTime.UtcNow.AddHours(5);

                db.StudentFeeRecords.Add(finalslip);
                db.SaveChanges();
                db.Entry(finalslip).GetDatabaseValues();
                int getid = finalslip.Id;
                TempData["Feeid"] = getid;
                //here  saving the created record of each specific tranaction
                db.transactionecords.Add(transaction);
                db.SaveChanges();
               
                
                return RedirectToAction("PrintSlip");
            }
            

            ViewBag.StudentId = new SelectList(db.students, "Id", "StudentName", studentFeeRecords.StudentId);
            return View(studentFeeRecords);
        }
        public ActionResult PrintSlip()
        {
            int id = Convert.ToInt32(TempData["Feeid"]);
            if (id ==0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentFeeRecords studentFeeRecords = db.StudentFeeRecords.Find(Convert.ToInt32(id));
            if (studentFeeRecords == null)
            {
                return HttpNotFound();
            }
            return View(studentFeeRecords);
          
        }

        // GET: StudentFeeRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentFeeRecords studentFeeRecords = db.StudentFeeRecords.Find(id);
            if (studentFeeRecords == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.students, "Id", "StudentName", studentFeeRecords.StudentId);
            return View(studentFeeRecords);
        }

        // POST: StudentFeeRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FatherName,SemesterClass,SubmissionDate,AdmissionFeeTutionFee,HostelFee,SecFee,PaymentMethod,GrossTotalAmount,Payingstatus,Year,batch,Remarks,StudentId")] StudentFeeRecords studentFeeRecords)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentFeeRecords).State = EntityState.Modified;
                db.SaveChanges();//here its is bug on the year format attribute will solve soon (pending).
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.students, "Id", "StudentName", studentFeeRecords.StudentId);
            return View(studentFeeRecords);
        }

        // GET: StudentFeeRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentFeeRecords studentFeeRecords = db.StudentFeeRecords.Find(id);
            if (studentFeeRecords == null)
            {
                return HttpNotFound();
            }
            return View(studentFeeRecords);
        }

        // POST: StudentFeeRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentFeeRecords studentFeeRecords = db.StudentFeeRecords.Find(id);
            db.StudentFeeRecords.Remove(studentFeeRecords);
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
