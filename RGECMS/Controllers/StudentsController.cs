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
using PagedList;
using System.IO;

namespace RGECMS.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Students
        public ActionResult Index(string search, int? page)
        {
            var students = db.students.Include(s => s.Programs).ToList();

            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                students = students.Where(m => m.Id == convertsearch).ToList();
                TempData["student"] = students.Count();

            }
            if (string.IsNullOrWhiteSpace(search))
            {
                TempData["student"] = students.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(students.OrderByDescending(a => a.AddmissionDate).ToPagedList(pageNumber, pageSize));
        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = await db.students.FindAsync(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Students students, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {

                if (ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(students.ImageFile.FileName);
                    string extension = Path.GetExtension(students.ImageFile.FileName);

                    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    students.Uploadimage = "~/image/" + fileName;
                    students.ImageFile.SaveAs(Path.Combine(Server.MapPath("~/image/"), fileName));
                }

                students.ClassId = 0;
                students.Status = "Present";
                students.CurrentSemclass = "N/A";
                //onSideLeads.CreatedOn = DateTime.UtcNow.AddHours(5);
                students.AddedOn = DateTime.UtcNow.AddHours(5);
                db.students.Add(students);
                await db.SaveChangesAsync();
                db.Entry(students).GetDatabaseValues();
                int getid = students.Id;
                if (getid > 0)
                {
                    TempData["regsuccess"] = "Student Registration No" + ": " + getid + " " + "Student Name:" + " " + students.StudentName;
                }
                return RedirectToAction("Index");
            }

            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName", students.ProgramId);
            return View(students);
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = await db.students.FindAsync(id);
            TempData["photo"] = students.Uploadimage;
            if (students == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName", students.ProgramId);
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Students students, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(students.ImageFile.FileName);
                    string extension = Path.GetExtension(students.ImageFile.FileName);

                    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    students.Uploadimage = "~/image/" + fileName;
                    students.ImageFile.SaveAs(Path.Combine(Server.MapPath("~/image/"), fileName));
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        db.Entry(students).State = EntityState.Modified;

                        db.SaveChanges();
                    }
                }

                else
                {
                    students.Uploadimage = TempData["photo"].ToString();
                    db.Entry(students).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            ViewBag.ProgramId = new SelectList(db.programs, "Id", "ProgramName", students.ProgramId);//here i replace the class with programs
            return View(students);
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = await db.students.FindAsync(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Students students = await db.students.FindAsync(id);
            db.students.Remove(students);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //public ActionResult show()
        //{
        //    var students = db.students.Include(s => s.Programs).ToList();
  
        //    return View(students);

        //}
        //public async Task<ActionResult> AssignBook(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    //Students students = await db.students.FindAsync(id);
        //    return View(await db.LibarayIssuedBooks.Where(x => x.StudedRegId ==id).ToListAsync());
        //    //if (students == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(students);
        //}

        //public async Task<ActionResult> AssignBook(Students students)
        //{

        //    return View(await db.LibarayIssuedBooks.Where(x => x.StudedRegId == students.Id).ToListAsync());


        //}

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
