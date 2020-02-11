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
    public class TeacherclassAssigningsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeacherclassAssignings
        public ActionResult Index(string search, int? page)
        {
            var teacherclassAssigning = db.TeacherclassAssigning.Include(t => t.Program).ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                teacherclassAssigning = teacherclassAssigning.Where(m => m.Teacherid == convertsearch).ToList();
                TempData["Totaluser"] = teacherclassAssigning.Count();
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                TempData["Totaluser"] = teacherclassAssigning.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(teacherclassAssigning.OrderByDescending(m => m.AssignedDate).ToPagedList(pageNumber, pageSize));
        }

        // GET: TeacherclassAssignings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherclassAssigning teacherclassAssigning = db.TeacherclassAssigning.Find(id);
            if (teacherclassAssigning == null)
            {
                return HttpNotFound();
            }
            return View(teacherclassAssigning);
        }

        // GET: TeacherclassAssignings/Create
        public ActionResult Create()
        {
            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName");
            ViewBag.TeacherId = db.Teachers.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Id.ToString() })
.ToList();
            return View();
        }

        // POST: TeacherclassAssignings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( TeacherclassAssigning teacherclassAssigning)
        {
            TeacherCoursesRecord instance = new TeacherCoursesRecord();
            if (ModelState.IsValid)
            {
                var classname = (from alias in db.classes where alias.Id == teacherclassAssigning.ClassId select alias.ClassName).FirstOrDefault();
                var programname = (from alias in db.programs where alias.Id == teacherclassAssigning.ProgramId select alias.ProgramName).FirstOrDefault();
                var subjectname = (from alias in db.subject where alias.Id == teacherclassAssigning.SubjectId select alias.SubjectName).FirstOrDefault();
                teacherclassAssigning.Name = (from alias in db.Teachers where alias.Id == teacherclassAssigning.Teacherid select alias.TeacherName).FirstOrDefault();
                teacherclassAssigning.AssignedDate = DateTime.Now;
                teacherclassAssigning.ClassName = classname;
                teacherclassAssigning.SubjectName = subjectname;
                teacherclassAssigning.ProgramName = programname;
                db.TeacherclassAssigning.Add(teacherclassAssigning);
                db.SaveChanges();
                //here assigned histroy record is creating
                db.Entry(teacherclassAssigning).GetDatabaseValues();
                int asignid = teacherclassAssigning.id;
                instance.Teacherid = teacherclassAssigning.Teacherid;
                instance.Name = teacherclassAssigning.Name;
                instance.AssignedDate = teacherclassAssigning.AssignedDate;
                instance.Assignedprocessid = asignid;
                instance.ClassId = teacherclassAssigning.ClassId;
                instance.ProgramId = teacherclassAssigning.ProgramId;
                instance.SubjectId = teacherclassAssigning.SubjectId;
                instance.ProgramName = programname;
                instance.ClassName = classname;
                instance.SubjectName = subjectname;


                db.TeacherCoursesRecord.Add(instance);
                db.SaveChanges();
             
                    TempData["message"] = "Sucessfully Class Subject is Assigned to" + instance.Name;
             
              
                //end record saved

                return RedirectToAction("Index");
            }
         
            

            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName", teacherclassAssigning.ProgramId);
            ViewBag.TeacherId = db.Teachers.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Id.ToString() })
.ToList();
            return View(teacherclassAssigning);
        }

        //start of ajax for class 
        public JsonResult Getallclassess(string id)
        {
            if (id == "0")
            {
                return Json("Not Found");
            }


            var programid = Convert.ToInt32(id);
            var clasess = db.classes.Where(s => s.ProgramId.Equals(programid)).ToList();
            return Json(new SelectList(clasess, "Id", "ClassName"));
        } //end json for retreving  classes
          //start of ajax for class 
        public JsonResult Getallsubjects(string id)
        {
            if (id == "0")
            {
                return Json("Not Found");
            }


            var classid = Convert.ToInt32(id);
            var Subjects = db.subject.Where(s => s.ClassId.Equals(classid)).ToList();
            return Json(new SelectList(Subjects, "Id", "SubjectName"));
        } //end json for retreving  classes

        // GET: TeacherclassAssignings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherclassAssigning teacherclassAssigning = db.TeacherclassAssigning.Find(id);
            if (teacherclassAssigning == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName", teacherclassAssigning.ProgramId);
            return View(teacherclassAssigning);
        }

        // POST: TeacherclassAssignings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Teacherid,Name,AssignedDate,ProgramId,ClassId,SubjectId")] TeacherclassAssigning teacherclassAssigning)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherclassAssigning).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName", teacherclassAssigning.ProgramId);
            return View(teacherclassAssigning);
        }

        // GET: TeacherclassAssignings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherclassAssigning teacherclassAssigning = db.TeacherclassAssigning.Find(id);
            if (teacherclassAssigning == null)
            {
                return HttpNotFound();
            }
            return View(teacherclassAssigning);
        }

        // POST: TeacherclassAssignings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherclassAssigning teacherclassAssigning = db.TeacherclassAssigning.Find(id);
            db.TeacherclassAssigning.Remove(teacherclassAssigning);
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
