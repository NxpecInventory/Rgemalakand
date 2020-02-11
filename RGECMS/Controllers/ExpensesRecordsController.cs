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
    public class ExpensesRecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExpensesRecords
        public  ActionResult Index(string CategoryId, int? page)
        {
            var expensesRecords = db.ExpensesRecords.Include(e => e.collegeExpenseCategories).ToList();

            ViewBag.CategoryId = new SelectList(db.collegeExpenseCategories, "Id", "Categories");

            if (!string.IsNullOrWhiteSpace(CategoryId))
            {
                int convertsearch = Convert.ToInt32(CategoryId);
                page = 1;
                expensesRecords = expensesRecords.Where(m => m.CategoryId == convertsearch).ToList();
                TempData["Totaluser"] = expensesRecords.Count();
            }
            if (string.IsNullOrWhiteSpace(CategoryId))
            {
                TempData["Totaluser"] = expensesRecords.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(expensesRecords.OrderByDescending(a => a.PayingDate).ToPagedList(pageNumber, pageSize));
        }

        // GET: ExpensesRecords/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpensesRecords expensesRecords = await db.ExpensesRecords.FindAsync(id);
            if (expensesRecords == null)
            {
                return HttpNotFound();
            }
            return View(expensesRecords);
        }

        // GET: ExpensesRecords/Create
        public ActionResult Create()
        {
            var view = new ExpensesRecords
            {

               TransactionYear = DateTime.Now.Year,
                PayingDate=DateTime.Now.Date,
             




            };
            ViewBag.CategoryId = new SelectList(db.collegeExpenseCategories, "Id", "Categories");
            return View(view);
        }

        // POST: ExpensesRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RecieverName,PayingDate,ItemQuantity,ItemName,CategoryId,TransactionYear,PaidAmount")] ExpensesRecords expensesRecords)
        {
          
            if (ModelState.IsValid)
            {
                expensesRecords.TransactionYear = DateTime.Now.Year;
                db.ExpensesRecords.Add(expensesRecords);
                await db.SaveChangesAsync();
                db.Entry(expensesRecords).GetDatabaseValues();
                int salaryrecid = expensesRecords.Id;
                //here inserting inventory expense records into the expense outgoing mpdel
                ExpenseOutgoingRecords expensetransection = new ExpenseOutgoingRecords();
                expensetransection.RecordId = salaryrecid;
                expensetransection.Personid = 0;
                expensetransection.PersonName = expensesRecords.RecieverName;
                expensetransection.TransactionType = "Inventory Expense";
                expensetransection.TransactionDate = expensesRecords.PayingDate;
                expensetransection.TransactionYear =expensesRecords.TransactionYear;
                expensetransection.TransactionAmount = expensesRecords.PaidAmount;
                db.ExpenseOutgoingRecords.Add(expensetransection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.collegeExpenseCategories, "Id", "Categories", expensesRecords.CategoryId);
            return View(expensesRecords);
        }

        // GET: ExpensesRecords/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpensesRecords expensesRecords = await db.ExpensesRecords.FindAsync(id);
            if (expensesRecords == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.collegeExpenseCategories, "Id", "Categories", expensesRecords.CategoryId);
            return View(expensesRecords);
        }

        // POST: ExpensesRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RecieverName,PayingDate,ItemQuantity,ItemName,CategoryId,TransactionYear,PaidAmount")] ExpensesRecords expensesRecords)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expensesRecords).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.collegeExpenseCategories, "Id", "Categories", expensesRecords.CategoryId);
            return View(expensesRecords);
        }

        // GET: ExpensesRecords/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpensesRecords expensesRecords = await db.ExpensesRecords.FindAsync(id);
            if (expensesRecords == null)
            {
                return HttpNotFound();
            }
            return View(expensesRecords);
        }

        // POST: ExpensesRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ExpensesRecords expensesRecords = await db.ExpensesRecords.FindAsync(id);
            db.ExpensesRecords.Remove(expensesRecords);
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
