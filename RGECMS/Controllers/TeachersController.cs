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
using System.IO;

namespace RGECMS.Controllers
{
    public class TeachersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teachers
        public ActionResult Index(string search, int? page)
        {
            var teachers = db.Teachers.Include(t => t.teacherdesignationcategory).ToList();

            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                teachers = teachers.Where(m => m.Id == convertsearch).ToList();
                TempData["Totaluser"] = teachers.Count();
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                TempData["Totaluser"] = teachers.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(teachers.OrderByDescending(m=>m.JoiningDate).ToPagedList(pageNumber, pageSize));
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers teachers = db.Teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(db.teacherdesignationcategory, "Id", "DepartmentName");
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase ImageFile,Teachers model)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension = Path.GetExtension(model.ImageFile.FileName);

                    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    model.Uploadimage = "~/image/" + fileName;
                    model.ImageFile.SaveAs(Path.Combine(Server.MapPath("~/image/"), fileName));
                    /////////////
                    ///

                    //string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    //string extension = Path.GetExtension(model.ImageFile.FileName).Substring(1);
                    ////file
                    ////  extension = ImageFile.Substring(ImageFile.lastIndexOf('.') + 1).toLowerCase();
                    ////if (extension == "jpg" || extension == "png" || extension == "bmp")
                    ////{
                    ////    if (!supportedTypes.Contains(extension))
                    ////    {
                    ////        result = false;
                    ////    }
                    ////    else
                    ////    {
                    ////        file storage
                    //    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    //        model.Uploadimage = extension;
                    //        model.ImageFile.SaveAs(Path.Combine(Server.MapPath("~/image"), extension));





                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        db.Teachers.Add(model);
                        db.SaveChanges();
                        TempData["msg"] = "SucessFully Created Teacher Record Of  Name:" + model.TeacherName;
                    }
                    return RedirectToAction("Index");
                }
            }

            ViewBag.DesignationId = new SelectList(db.teacherdesignationcategory, "Id", "DepartmentName", model.DesignationId);
            return View(model);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers teachers = db.Teachers.Find(id);
            TempData["image"] = teachers.Uploadimage;
            if (teachers == null)
            {
                return HttpNotFound();
            }
            ViewBag.DesignationId = new SelectList(db.teacherdesignationcategory, "Id", "DepartmentName", teachers.DesignationId);
            return View(teachers);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase ImageFile,/*[Bind(Include = "Id,TeacherName,FatherName,Address,ContactInfo,Status,JoiningDate,DesignationId,Specialization,Uploadimage,")]*/ Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(teachers.ImageFile.FileName);
                    string extension = Path.GetExtension(teachers.ImageFile.FileName);

                    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    teachers.Uploadimage = "~/image/" + fileName;
                    teachers.ImageFile.SaveAs(Path.Combine(Server.MapPath("~/image/"), fileName));
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        db.Entry(teachers).State = EntityState.Modified;
                      
                        db.SaveChanges();
                    }
                }
                else
                {
                    teachers.Uploadimage = TempData["image"].ToString();
                    db.Entry(teachers).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
               
            }
            ViewBag.DesignationId = new SelectList(db.teacherdesignationcategory, "Id", "DepartmentName", teachers.DesignationId);
            return View(teachers);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers teachers = db.Teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teachers teachers = db.Teachers.Find(id);
            db.Teachers.Remove(teachers);
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
