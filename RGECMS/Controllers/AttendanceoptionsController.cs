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
    public class AttendanceoptionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attendanceoptions
        public async Task<ActionResult> Index()
        {
            return View(await db.options.ToListAsync());
        }

        // GET: Attendanceoptions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendanceoptions attendanceoptions = await db.options.FindAsync(id);
            if (attendanceoptions == null)
            {
                return HttpNotFound();
            }
            return View(attendanceoptions);
        }

        // GET: Attendanceoptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attendanceoptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Options")] Attendanceoptions attendanceoptions)
        {
            if (ModelState.IsValid)
            {
                db.options.Add(attendanceoptions);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(attendanceoptions);
        }

        // GET: Attendanceoptions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendanceoptions attendanceoptions = await db.options.FindAsync(id);
            if (attendanceoptions == null)
            {
                return HttpNotFound();
            }
            return View(attendanceoptions);
        }

        // POST: Attendanceoptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Options")] Attendanceoptions attendanceoptions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendanceoptions).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(attendanceoptions);
        }

        // GET: Attendanceoptions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendanceoptions attendanceoptions = await db.options.FindAsync(id);
            if (attendanceoptions == null)
            {
                return HttpNotFound();
            }
            return View(attendanceoptions);
        }

        // POST: Attendanceoptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Attendanceoptions attendanceoptions = await db.options.FindAsync(id);
            db.options.Remove(attendanceoptions);
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
