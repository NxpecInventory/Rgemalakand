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
    public class ClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Classes
        public async Task<ActionResult> Index()
        {
            var classes = db.classes.Include(c => c.Program);
            return View(await classes.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classes classes = await db.classes.FindAsync(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ClassName,ProgramId")] Classes classes)
        {
            if (ModelState.IsValid)
            {
                db.classes.Add(classes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName", classes.ProgramId);
            return View(classes);
        }

        // GET: Classes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classes classes = await db.classes.FindAsync(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName", classes.ProgramId);
            return View(classes);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ClassName,ProgramId")] Classes classes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName", classes.ProgramId);
            return View(classes);
        }

        // GET: Classes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classes classes = await db.classes.FindAsync(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Classes classes = await db.classes.FindAsync(id);
            db.classes.Remove(classes);
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
