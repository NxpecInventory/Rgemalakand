using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RGECMS.Models;
using System.IO;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace RGECMS.Controllers
{
    public class CollegeFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
      private  ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext
            ().GetUserManager<ApplicationUserManager>().FindById
            (System.Web.HttpContext.Current.User.Identity.GetUserId());
        // GET: CollegeFiles
        public ActionResult Index()
        {
            var getspecific = db.CollegeFiles.Where(a => a.uploderid == user.RegistrationNo).ToList();

            return View(getspecific);
        }

        // GET: CollegeFiles/Details/5
      
        // GET: CollegeFiles/Create
        public ActionResult Create()
        {
            return View(new uploadingfileviewmodel());
        }

        // POST: CollegeFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(uploadingfileviewmodel model)
        {
            if (ModelState.IsValid)
            {
                if (model.file == null || model.file.ContentLength == 0)
                {
                    ModelState.AddModelError("Please Upload the File To Proceed", "This field is Required");
                }



                if (model.file != null && model.file.ContentLength > 0)
                {
                    var uploadDir = "~/UploadedFiles";
                    var filepath = Path.Combine(Server.MapPath(uploadDir), model.file.FileName);
                    var fileurl = Path.Combine(uploadDir, model.file.FileName);
                    model.file.SaveAs(filepath);
                    CollegeFiles collegefiles = new CollegeFiles();
                    collegefiles.filepath = fileurl;
                    collegefiles.FileCat = model.FileCat;
                    collegefiles.FileDescription = model.FileDescription;
                 
                    collegefiles.uploderid = user.RegistrationNo;//here i hard coded for the testing and working purpose (dynamic added now its working and fully dynamic sloved the hardcoded)
                    var getname = (from alias in db.Teachers where alias.Id == collegefiles.uploderid select alias.TeacherName).FirstOrDefault();
                    collegefiles.UploadingDate = DateTime.Now;
                    collegefiles.Uploadername = getname;
                    db.CollegeFiles.Add(collegefiles);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }



            }

            return View(model);
        }

        // GET: CollegeFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollegeFiles collegeFiles = db.CollegeFiles.Find(id);
            if (collegeFiles == null)
            {
                return HttpNotFound();
            }
           
            return View(collegeFiles);
        }

        // POST: CollegeFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CollegeFiles collegefiles)
        {
       
            if (ModelState.IsValid)
            { db.Entry(collegefiles).State = EntityState.Modified;
                     db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(collegefiles);
        }

        // GET: CollegeFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollegeFiles collegeFiles = db.CollegeFiles.Find(id);
            if (collegeFiles == null)
            {
                return HttpNotFound();
            }
            return View(collegeFiles);
        }

        // POST: CollegeFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CollegeFiles collegeFiles = db.CollegeFiles.Find(id);
        
            if (System.IO.File.Exists(collegeFiles.filepath))
            {
                System.IO.File.Delete(collegeFiles.filepath);
            }
            db.CollegeFiles.Remove(collegeFiles);
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
