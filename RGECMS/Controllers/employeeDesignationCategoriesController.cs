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
    public class employeeDesignationCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: employeeDesignationCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.employeeDesignationCategory.ToListAsync());
        }

        // GET: employeeDesignationCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeDesignationCategory employeeDesignationCategory = await db.employeeDesignationCategory.FindAsync(id);
            if (employeeDesignationCategory == null)
            {
                return HttpNotFound();
            }
            return View(employeeDesignationCategory);
        }

        // GET: employeeDesignationCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeeDesignationCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DesignationName")] employeeDesignationCategory employeeDesignationCategory)
        {
            if (ModelState.IsValid)
            {
                db.employeeDesignationCategory.Add(employeeDesignationCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employeeDesignationCategory);
        }

        // GET: employeeDesignationCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeDesignationCategory employeeDesignationCategory = await db.employeeDesignationCategory.FindAsync(id);
            if (employeeDesignationCategory == null)
            {
                return HttpNotFound();
            }
            return View(employeeDesignationCategory);
        }

        // POST: employeeDesignationCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DesignationName")] employeeDesignationCategory employeeDesignationCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDesignationCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employeeDesignationCategory);
        }

        // GET: employeeDesignationCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeDesignationCategory employeeDesignationCategory = await db.employeeDesignationCategory.FindAsync(id);
            if (employeeDesignationCategory == null)
            {
                return HttpNotFound();
            }
            return View(employeeDesignationCategory);
        }

        // POST: employeeDesignationCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            employeeDesignationCategory employeeDesignationCategory = await db.employeeDesignationCategory.FindAsync(id);
            db.employeeDesignationCategory.Remove(employeeDesignationCategory);
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
