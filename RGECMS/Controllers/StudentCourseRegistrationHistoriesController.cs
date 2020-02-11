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
    public class StudentCourseRegistrationHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentCourseRegistrationHistories
        public ActionResult Index(string search, int? page)
        {
            var history = db.StudentCourseRegistrationHistory.ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                history = history.Where(m => m.Studentid == convertsearch).ToList();
                TempData["Totaluser"] = history.Count();
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                TempData["Totaluser"] = history.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(history.OrderByDescending(m => m.AssignedDate).ToPagedList(pageNumber, pageSize));
        }
  

        // GET: StudentCourseRegistrationHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourseRegistrationHistory studentCourseRegistrationHistory = db.StudentCourseRegistrationHistory.Find(id);
            if (studentCourseRegistrationHistory == null)
            {
                return HttpNotFound();
            }
            return View(studentCourseRegistrationHistory);
        }

        // GET: StudentCourseRegistrationHistories/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: StudentCourseRegistrationHistories/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,Regid,Studentid,StudentName,year,AssignedDate,ProgramId,ClassId,Comments")] StudentCourseRegistrationHistory studentCourseRegistrationHistory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.StudentCourseRegistrationHistory.Add(studentCourseRegistrationHistory);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(studentCourseRegistrationHistory);
        //}

        // GET: StudentCourseRegistrationHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourseRegistrationHistory studentCourseRegistrationHistory = db.StudentCourseRegistrationHistory.Find(id);
            if (studentCourseRegistrationHistory == null)
            {
                return HttpNotFound();
            }
            return View(studentCourseRegistrationHistory);
        }

        // POST: StudentCourseRegistrationHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Regid,Studentid,StudentName,year,AssignedDate,ProgramId,ClassId,Comments")] StudentCourseRegistrationHistory studentCourseRegistrationHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCourseRegistrationHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentCourseRegistrationHistory);
        }

        // GET: StudentCourseRegistrationHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourseRegistrationHistory studentCourseRegistrationHistory = db.StudentCourseRegistrationHistory.Find(id);
            if (studentCourseRegistrationHistory == null)
            {
                return HttpNotFound();
            }
            return View(studentCourseRegistrationHistory);
        }

        // POST: StudentCourseRegistrationHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCourseRegistrationHistory studentCourseRegistrationHistory = db.StudentCourseRegistrationHistory.Find(id);
            db.StudentCourseRegistrationHistory.Remove(studentCourseRegistrationHistory);
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
