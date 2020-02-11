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

namespace RGECMS.Controllers
{
    public class collegeExpenseCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: collegeExpenseCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.collegeExpenseCategories.ToListAsync());
        }

        // GET: collegeExpenseCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            collegeExpenseCategories collegeExpenseCategories = await db.collegeExpenseCategories.FindAsync(id);
            if (collegeExpenseCategories == null)
            {
                return HttpNotFound();
            }
            return View(collegeExpenseCategories);
        }

        // GET: collegeExpenseCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: collegeExpenseCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Categories")] collegeExpenseCategories collegeExpenseCategories)
        {
            if (ModelState.IsValid)
            {
                db.collegeExpenseCategories.Add(collegeExpenseCategories);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(collegeExpenseCategories);
        }

        // GET: collegeExpenseCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            collegeExpenseCategories collegeExpenseCategories = await db.collegeExpenseCategories.FindAsync(id);
            if (collegeExpenseCategories == null)
            {
                return HttpNotFound();
            }
            return View(collegeExpenseCategories);
        }

        // POST: collegeExpenseCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Categories")] collegeExpenseCategories collegeExpenseCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collegeExpenseCategories).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(collegeExpenseCategories);
        }

        // GET: collegeExpenseCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            collegeExpenseCategories collegeExpenseCategories = await db.collegeExpenseCategories.FindAsync(id);
            if (collegeExpenseCategories == null)
            {
                return HttpNotFound();
            }
            return View(collegeExpenseCategories);
        }

        // POST: collegeExpenseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            collegeExpenseCategories collegeExpenseCategories = await db.collegeExpenseCategories.FindAsync(id);
            db.collegeExpenseCategories.Remove(collegeExpenseCategories);
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
