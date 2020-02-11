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
    public class ProgramsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Programs
        public async Task<ActionResult> Index()
        {
            return View(await db.programs.ToListAsync());
        }

        // GET: Programs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programs programs = await db.programs.FindAsync(id);
            if (programs == null)
            {
                return HttpNotFound();
            }
            return View(programs);
        }

        // GET: Programs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProgramName,ProgramStartingDate")] Programs programs)
        {
            if (ModelState.IsValid)
            {
                db.programs.Add(programs);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(programs);
        }

        // GET: Programs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programs programs = await db.programs.FindAsync(id);
            if (programs == null)
            {
                return HttpNotFound();
            }
            return View(programs);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProgramName,ProgramStartingDate")] Programs programs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(programs);
        }

        // GET: Programs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programs programs = await db.programs.FindAsync(id);
            if (programs == null)
            {
                return HttpNotFound();
            }
            return View(programs);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Programs programs = await db.programs.FindAsync(id);
            db.programs.Remove(programs);
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
