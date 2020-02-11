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
    public class StudentClassAssigningSystemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentClassAssigningSystems
        public ActionResult Index(string search, int? page)
        {
            var studentClassAssigningSystem = db.StudentClassAssigningSystem.Include(s => s.Program).ToList();
            TempData["check"] = Registrationactionsclass.checkopenorclose();
            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                studentClassAssigningSystem = studentClassAssigningSystem.Where(m => m.Studentid == convertsearch).ToList();
                TempData["Totaluser"] = studentClassAssigningSystem.Count();
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                TempData["Totaluser"] = studentClassAssigningSystem.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);

            return View(studentClassAssigningSystem.OrderByDescending(m => m.AssignedDate).ToPagedList(pageNumber, pageSize));
          
        }

        // GET: StudentClassAssigningSystems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClassAssigningSystem studentClassAssigningSystem = db.StudentClassAssigningSystem.Find(id);
            if (studentClassAssigningSystem == null)
            {
                return HttpNotFound();
            }
            return View(studentClassAssigningSystem);
        }

        // GET: StudentClassAssigningSystems/Create
        public ActionResult Create()
        {
            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName");
            ViewBag.StudentId = db.students.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Id.ToString() }).ToList();
            return View();
        }
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

        // POST: StudentClassAssigningSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentClassAssigningSystem studentClassAssigningSystem)
        {
            StudentCoursesBucket studentbucket = new StudentCoursesBucket();
            StudentCourseRegistrationHistory studentcoursehistory = new StudentCourseRegistrationHistory();



            if (ModelState.IsValid)
            {
                try
                {
                    if (studentClassAssigningSystem.Comments == null)
                    {
                        studentClassAssigningSystem.Comments = "Comment N/A";
                    }
                    studentClassAssigningSystem.AssignedDate = DateTime.Now.Date;
                    studentClassAssigningSystem.year = DateTime.Now.Year;

                    studentClassAssigningSystem.ClassName =
                        (from alias in db.classes where alias.Id == studentClassAssigningSystem.ClassId select alias.ClassName).FirstOrDefault();
                    studentClassAssigningSystem.ProgramName =
                      (from alias in db.programs where alias.Id == studentClassAssigningSystem.ProgramId select alias.ProgramName).FirstOrDefault();

                    studentClassAssigningSystem.StudentName =
                        (from alias in db.students where alias.Id == studentClassAssigningSystem.Studentid select alias.StudentName).FirstOrDefault();
                    //here am updating the student model and in that model updating student recent class id by new one 
                    Students student = db.students.Find(studentClassAssigningSystem.Studentid);
                    student.ClassId = studentClassAssigningSystem.ClassId;
                    student.CurrentSemclass = studentClassAssigningSystem.ClassName;//here i update after student updating by program

                    var checkingmatchentry =
                        (from alias in db.StudentClassAssigningSystem where alias.Studentid == studentClassAssigningSystem.Studentid select alias.id).FirstOrDefault();
                    StudentClassAssigningSystem checkingSystem = db.StudentClassAssigningSystem.Find(checkingmatchentry);
                    var checkingbucket =
                        (from alias in db.StudentCoursesBucket where alias.Regid == checkingmatchentry select alias.id).FirstOrDefault();
                    StudentCoursesBucket coursesbucket = db.StudentCoursesBucket.Find(checkingbucket);
                    var checkinghistory =
                        (from alias in db.StudentCourseRegistrationHistory where alias.Regid == checkingmatchentry select alias.id).FirstOrDefault();
                    StudentCourseRegistrationHistory courseshistory = db.StudentCourseRegistrationHistory.Find(checkinghistory);
                    if (checkingSystem != null)
                    {
                        //here deleting that record that is also exists removing that adding new record to that specific record 
                        db.StudentClassAssigningSystem.Remove(checkingSystem);
                        db.SaveChanges();
                        db.StudentCoursesBucket.Remove(coursesbucket);
                        db.SaveChanges();
                        db.StudentCourseRegistrationHistory.Remove(courseshistory);
                        db.SaveChanges();

                    }
                    db.StudentClassAssigningSystem.Add(studentClassAssigningSystem);
                    db.SaveChanges();
                    db.Entry(studentClassAssigningSystem).GetDatabaseValues();
                    //here inserting record into student bucket 
                    int regid = studentClassAssigningSystem.id;
                    studentbucket.Regid = regid;
                    studentbucket.Studentid = studentClassAssigningSystem.Studentid;
                    studentbucket.StudentName = studentClassAssigningSystem.StudentName;
                    studentbucket.year = studentClassAssigningSystem.year;
                    studentbucket.AssignedDate = studentClassAssigningSystem.AssignedDate;
                    studentbucket.ProgramId = studentClassAssigningSystem.ProgramId;
                    studentbucket.ClassId = studentClassAssigningSystem.ClassId;
                    studentbucket.Comments = studentClassAssigningSystem.Comments;
                    studentbucket.ClassName = studentClassAssigningSystem.ClassName;
                    studentbucket.ProgramName = studentClassAssigningSystem.ProgramName;
                    db.StudentCoursesBucket.Add(studentbucket);
                    db.SaveChanges();
                    //here inserting reg courses into student bucket ends and college history inserting of couses are statrted below
                     studentcoursehistory.Regid = regid;
                    studentcoursehistory.Studentid = studentClassAssigningSystem.Studentid;
                    studentcoursehistory.StudentName = studentClassAssigningSystem.StudentName;
                    studentcoursehistory.year = studentClassAssigningSystem.year;
                    studentcoursehistory.AssignedDate = studentClassAssigningSystem.AssignedDate;
                    studentcoursehistory.ProgramId = studentClassAssigningSystem.ProgramId;
                    studentcoursehistory.ClassId = studentClassAssigningSystem.ClassId;
                    studentcoursehistory.Comments = studentClassAssigningSystem.Comments;
                    studentcoursehistory.ClassName = studentClassAssigningSystem.ClassName;
                    studentcoursehistory.ProgramName = studentClassAssigningSystem.ProgramName;
                    db.StudentCourseRegistrationHistory.Add(studentcoursehistory);
                    db.SaveChanges();
                    //here updating student records updated class id

                    db.Entry(student).State = EntityState.Modified;
                }
                catch
                {
                    TempData["regerror"] = "An Error Occured During The Class Registration Process Please Check Your Internet Connectivity and makesure that the Class registration Is Open ";
                    return RedirectToAction("Index");
                }
                TempData["regmsg"] = "Sucessfully "+studentClassAssigningSystem.ClassName+" Is Assigned To the Student Name:" + studentcoursehistory.StudentName + "Student Id:" + studentcoursehistory.Studentid + ".The Registration Id of class/Semester Registration Is: " + studentcoursehistory.Regid;
                return RedirectToAction("Index");
            }
          
            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName", studentClassAssigningSystem.ProgramId);
            ViewBag.TeacherId = db.students.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Id.ToString() })
.ToList();
            return View(studentClassAssigningSystem);
        }

        // GET: StudentClassAssigningSystems/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    StudentClassAssigningSystem studentClassAssigningSystem = db.StudentClassAssigningSystem.Find(id);
        //    if (studentClassAssigningSystem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName", studentClassAssigningSystem.ProgramId);
        //    return View(studentClassAssigningSystem);
        //}

        //// POST: StudentClassAssigningSystems/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,Studentid,StudentName,year,AssignedDate,ProgramId,ClassId,Comments")] StudentClassAssigningSystem studentClassAssigningSystem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(studentClassAssigningSystem).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName", studentClassAssigningSystem.ProgramId);
        //    return View(studentClassAssigningSystem);
        //}

        // GET: StudentClassAssigningSystems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClassAssigningSystem studentClassAssigningSystem = db.StudentClassAssigningSystem.Find(id);
            if (studentClassAssigningSystem == null)
            {
                return HttpNotFound();
            }
            return View(studentClassAssigningSystem);
        }

        // POST: StudentClassAssigningSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentClassAssigningSystem studentClassAssigningSystem = db.StudentClassAssigningSystem.Find(id);
            db.StudentClassAssigningSystem.Remove(studentClassAssigningSystem);
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
