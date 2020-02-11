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
    public class ExpenseOutgoingRecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExpenseOutgoingRecords
        public ActionResult Index(string search, int? page)
        {
            var outgoing = db.ExpenseOutgoingRecords.ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                outgoing = outgoing.Where(m => m.Personid == convertsearch).ToList();
                TempData["Totaluser"] = outgoing.Count();
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                TempData["Totaluser"] = outgoing.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(outgoing.OrderByDescending(a=>a.TransactionDate).ToPagedList(pageNumber, pageSize));
        }

        // GET: ExpenseOutgoingRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseOutgoingRecords expenseOutgoingRecords = db.ExpenseOutgoingRecords.Find(id);
            if (expenseOutgoingRecords == null)
            {
                return HttpNotFound();
            }
            return View(expenseOutgoingRecords);
        }

        // GET: ExpenseOutgoingRecords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpenseOutgoingRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TransactionDate,TransactionType,RecordId,TransactionYear,TransactionAmount,PersonName,Personid")] ExpenseOutgoingRecords expenseOutgoingRecords)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseOutgoingRecords.Add(expenseOutgoingRecords);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expenseOutgoingRecords);
        }

        // GET: ExpenseOutgoingRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseOutgoingRecords expenseOutgoingRecords = db.ExpenseOutgoingRecords.Find(id);
            if (expenseOutgoingRecords == null)
            {
                return HttpNotFound();
            }
            return View(expenseOutgoingRecords);
        }

        // POST: ExpenseOutgoingRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TransactionDate,TransactionType,RecordId,TransactionYear,TransactionAmount,PersonName,Personid")] ExpenseOutgoingRecords expenseOutgoingRecords)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseOutgoingRecords).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseOutgoingRecords);
        }

        // GET: ExpenseOutgoingRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseOutgoingRecords expenseOutgoingRecords = db.ExpenseOutgoingRecords.Find(id);
            if (expenseOutgoingRecords == null)
            {
                return HttpNotFound();
            }
            return View(expenseOutgoingRecords);
        }

        // POST: ExpenseOutgoingRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseOutgoingRecords expenseOutgoingRecords = db.ExpenseOutgoingRecords.Find(id);
            db.ExpenseOutgoingRecords.Remove(expenseOutgoingRecords);
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
