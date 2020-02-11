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
    public class SubjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subjects
        public async Task<ActionResult> Index()
        {
            var subject = db.subject.Include(s => s.Classes);
            return View(await subject.ToListAsync());
        }

        // GET: Subjects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subjects subjects = await db.subject.FindAsync(id);
            if (subjects == null)
            {
                return HttpNotFound();
            }
            return View(subjects);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.classes, "Id", "ClassName");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SubjectName,ClassId")] Subjects subjects)
        {
            if (ModelState.IsValid)
            {
                db.subject.Add(subjects);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.classes, "Id", "ClassName", subjects.ClassId);
            return View(subjects);
        }

        // GET: Subjects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subjects subjects = await db.subject.FindAsync(id);
            if (subjects == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.classes, "Id", "ClassName", subjects.ClassId);
            return View(subjects);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SubjectName,ClassId")] Subjects subjects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjects).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.classes, "Id", "ClassName", subjects.ClassId);
            return View(subjects);
        }

        // GET: Subjects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subjects subjects = await db.subject.FindAsync(id);
            if (subjects == null)
            {
                return HttpNotFound();
            }
            return View(subjects);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Subjects subjects = await db.subject.FindAsync(id);
            db.subject.Remove(subjects);
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
