using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RGECMS.Models;

namespace RGECMS.Controllers
{
    public class teacherdesignationcategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: teacherdesignationcategories
        public ActionResult Index()
        {
            return View(db.teacherdesignationcategory.ToList());
        }

        // GET: teacherdesignationcategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacherdesignationcategory teacherdesignationcategory = db.teacherdesignationcategory.Find(id);
            if (teacherdesignationcategory == null)
            {
                return HttpNotFound();
            }
            return View(teacherdesignationcategory);
        }

        // GET: teacherdesignationcategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: teacherdesignationcategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartmentName")] teacherdesignationcategory teacherdesignationcategory)
        {
            if (ModelState.IsValid)
            {
                db.teacherdesignationcategory.Add(teacherdesignationcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacherdesignationcategory);
        }

        // GET: teacherdesignationcategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacherdesignationcategory teacherdesignationcategory = db.teacherdesignationcategory.Find(id);
            if (teacherdesignationcategory == null)
            {
                return HttpNotFound();
            }
            return View(teacherdesignationcategory);
        }

        // POST: teacherdesignationcategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartmentName")] teacherdesignationcategory teacherdesignationcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherdesignationcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherdesignationcategory);
        }

        // GET: teacherdesignationcategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacherdesignationcategory teacherdesignationcategory = db.teacherdesignationcategory.Find(id);
            if (teacherdesignationcategory == null)
            {
                return HttpNotFound();
            }
            return View(teacherdesignationcategory);
        }

        // POST: teacherdesignationcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teacherdesignationcategory teacherdesignationcategory = db.teacherdesignationcategory.Find(id);
            db.teacherdesignationcategory.Remove(teacherdesignationcategory);
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
