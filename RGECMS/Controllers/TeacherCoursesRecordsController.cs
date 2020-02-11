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
    public class TeacherCoursesRecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeacherCoursesRecords
        public ActionResult Index(string search, int? page)
        {
            var courses = db.TeacherCoursesRecord.ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                courses = courses.Where(m => m.Teacherid == convertsearch).ToList();
                TempData["Totaluser"] = courses.Count();
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                TempData["Totaluser"] = courses.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(courses.OrderByDescending(m=>m.id).ToPagedList(pageNumber, pageSize));
        }

        // GET: TeacherCoursesRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherCoursesRecord teacherCoursesRecord = db.TeacherCoursesRecord.Find(id);
            if (teacherCoursesRecord == null)
            {
                return HttpNotFound();
            }
            return View(teacherCoursesRecord);
        }

       

        // GET: TeacherCoursesRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherCoursesRecord teacherCoursesRecord = db.TeacherCoursesRecord.Find(id);
            if (teacherCoursesRecord == null)
            {
                return HttpNotFound();
            }
            return View(teacherCoursesRecord);
        }

      
        // GET: TeacherCoursesRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherCoursesRecord teacherCoursesRecord = db.TeacherCoursesRecord.Find(id);
            if (teacherCoursesRecord == null)
            {
                return HttpNotFound();
            }
            return View(teacherCoursesRecord);
        }

        // POST: TeacherCoursesRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherCoursesRecord teacherCoursesRecord = db.TeacherCoursesRecord.Find(id);
            db.TeacherCoursesRecord.Remove(teacherCoursesRecord);
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
