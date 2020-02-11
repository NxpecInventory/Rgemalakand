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
    public class transactionrecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: transactionrecords
        public ActionResult Index(string search, int? page)
        {
            var incomerecords = db.transactionecords.ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                incomerecords = incomerecords.Where(m => m.PersonId == convertsearch).ToList();
                TempData["Totaluser"] = incomerecords.Count();
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                TempData["Totaluser"] = incomerecords.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(incomerecords.OrderByDescending(a=>a.TransactionDate).ToPagedList(pageNumber, pageSize));
        }

        // GET: transactionrecords/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transactionrecords transactionrecords = await db.transactionecords.FindAsync(id);
            if (transactionrecords == null)
            {
                return HttpNotFound();
            }
            return View(transactionrecords);
        }

        // GET: transactionrecords/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: transactionrecords/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,TransactionDate,TransactionType,PersonId,TransactionYear,TransactionAmount")] transactionrecords transactionrecords)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.transactionecords.Add(transactionrecords);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(transactionrecords);
        //}

        // GET: transactionrecords/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transactionrecords transactionrecords = await db.transactionecords.FindAsync(id);
            if (transactionrecords == null)
            {
                return HttpNotFound();
            }
            return View(transactionrecords);
        }

        // POST: transactionrecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TransactionDate,TransactionType,PersonId,TransactionYear,TransactionAmount")] transactionrecords transactionrecords)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionrecords).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(transactionrecords);
        }

        // GET: transactionrecords/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transactionrecords transactionrecords = await db.transactionecords.FindAsync(id);
            if (transactionrecords == null)
            {
                return HttpNotFound();
            }
            return View(transactionrecords);
        }

        // POST: transactionrecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            transactionrecords transactionrecords = await db.transactionecords.FindAsync(id);
            db.transactionecords.Remove(transactionrecords);
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
