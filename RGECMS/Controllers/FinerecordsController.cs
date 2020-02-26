using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RGECMS.Models;
using PagedList;

namespace RGECMS.Controllers
{
    public class FinerecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Finerecords
        public ActionResult Index(string search, int? page)
        {
            var finerecords = db.Finerecords.Include(f => f.Students).ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                finerecords = finerecords.Where(m => m.StudentId == convertsearch).ToList();
                TempData["Totaluser"] = finerecords.Count();
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                TempData["Totaluser"] = finerecords.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(finerecords.OrderByDescending(m => m.SubmissionDate).ToPagedList(pageNumber, pageSize));
        }
    

        // GET: Finerecords/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finerecords finerecords = await db.Finerecords.FindAsync(id);
            if (finerecords == null)
            {
                return HttpNotFound();
            }
            return View(finerecords);
        }

        // GET: Finerecords/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = db.students.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Id.ToString() })
    .ToList();

            var view = new Finerecords
            {
                
                SubmissionDate = DateTime.Now.Date,
                Remarks = "Write Fine Reason/Category",
                Payingstatus="Full Fine Paid"

      


            };

            return View(view);
        }

        // POST: Finerecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Create( Finerecords finerecords)
        {

            if (finerecords!=null)
            {
               finerecords.TotalAmount = finerecords.FineAmount;
          

                int classid = (from alias in db.students where alias.Id == finerecords.StudentId select alias.ClassId).FirstOrDefault();
                finerecords.SemesterClass = (from alias in db.classes where alias.Id == classid select alias.ClassName).FirstOrDefault();
       
                 finerecords.Name = (from alias in db.students where alias.Id == finerecords.StudentId select alias.StudentName).FirstOrDefault();
               
            
              Finerecords fineslip = new Finerecords();
                transactionrecords transaction = new transactionrecords();

                fineslip.Id = finerecords.Id;

                fineslip.TotalAmount = finerecords.TotalAmount;
                fineslip.Payingstatus = finerecords.Payingstatus;
           
      
                fineslip.FineAmount = finerecords.FineAmount;
                fineslip.SubmissionDate = finerecords.SubmissionDate;
                fineslip.Remarks = finerecords.Remarks;
             
                //here normal record ends and students retrieving record start

                fineslip.SemesterClass = finerecords.SemesterClass;

                fineslip.Name = finerecords.Name;

                fineslip.StudentId = finerecords.StudentId;
                //here insterting transaction record
                transaction.PersonId = fineslip.StudentId;
                transaction.TransactionAmount = fineslip.TotalAmount;
                transaction.TransactionDate = fineslip.SubmissionDate;
                transaction.TransactionYear = DateTime.Now.Year;
                transaction.TransactionType = "Fine";



                db.Finerecords.Add(fineslip);
                await db.SaveChangesAsync();
                db.Entry(fineslip).GetDatabaseValues();
                int getid = fineslip.Id;
                TempData["Fineid"] = getid;
                //here  saving the created record of each specific tranaction
                db.transactionecords.Add(transaction);
                await db.SaveChangesAsync();

                return RedirectToAction("PrintfineSlip");
            }


            ViewBag.StudentId = new SelectList(db.students, "Id", "StudentName", finerecords.StudentId);
            return View(finerecords);
        }
        //here below is the fine slip
        public ActionResult PrintfineSlip()
        {
            int id = Convert.ToInt32(TempData["Fineid"]);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        Finerecords fineslip = db.Finerecords.Find(Convert.ToInt32(id));
            if (fineslip == null)
            {
                return HttpNotFound();
            }
            return View(fineslip);

        }
        // GET: Finerecords/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finerecords finerecords = await db.Finerecords.FindAsync(id);
            if (finerecords == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.students, "Id", "StudentName", finerecords.StudentId);
            return View(finerecords);
        }

        // POST: Finerecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,SemesterClass,SubmissionDate,FineAmount,TotalAmount,Payingstatus,Remarks,StudentId")] Finerecords finerecords)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finerecords).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.students, "Id", "StudentName", finerecords.StudentId);
            return View(finerecords);
        }

        // GET: Finerecords/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finerecords finerecords = await db.Finerecords.FindAsync(id);
            if (finerecords == null)
            {
                return HttpNotFound();
            }
            return View(finerecords);
        }

        // POST: Finerecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Finerecords finerecords = await db.Finerecords.FindAsync(id);
            db.Finerecords.Remove(finerecords);
            await db.SaveChangesAsync();
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
