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
    public class StudentCoursesBucketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentCoursesBuckets
        public ActionResult Index()
        {
            return View(db.StudentCoursesBucket.ToList());
        }

        // GET: StudentCoursesBuckets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCoursesBucket studentCoursesBucket = db.StudentCoursesBucket.Find(id);
            if (studentCoursesBucket == null)
            {
                return HttpNotFound();
            }
            return View(studentCoursesBucket);
        }

        // GET: StudentCoursesBuckets/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: StudentCoursesBuckets/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,Regid,Studentid,StudentName,year,AssignedDate,ProgramId,ClassId,Comments")] StudentCoursesBucket studentCoursesBucket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.StudentCoursesBucket.Add(studentCoursesBucket);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(studentCoursesBucket);
        //}

        //// GET: StudentCoursesBuckets/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StudentCoursesBucket studentCoursesBucket = db.StudentCoursesBucket.Find(id);
        //    if (studentCoursesBucket == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(studentCoursesBucket);
        //}

        //// POST: StudentCoursesBuckets/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,Regid,Studentid,StudentName,year,AssignedDate,ProgramId,ClassId,Comments")] StudentCoursesBucket studentCoursesBucket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(studentCoursesBucket).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(studentCoursesBucket);
        //}

        // GET: StudentCoursesBuckets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCoursesBucket studentCoursesBucket = db.StudentCoursesBucket.Find(id);
            if (studentCoursesBucket == null)
            {
                return HttpNotFound();
            }
            return View(studentCoursesBucket);
        }

        // POST: StudentCoursesBuckets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCoursesBucket studentCoursesBucket = db.StudentCoursesBucket.Find(id);
            db.StudentCoursesBucket.Remove(studentCoursesBucket);
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
