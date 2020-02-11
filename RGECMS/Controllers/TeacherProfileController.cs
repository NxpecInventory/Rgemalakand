using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RGECMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RGECMS.Controllers
{
    public class TeacherProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext
            ().GetUserManager<ApplicationUserManager>().FindById
            (System.Web.HttpContext.Current.User.Identity.GetUserId());
        // GET: TeacherProfile
        public ActionResult TeacherProfile()
        {
            Teachers teachers = db.Teachers.Find(user.RegistrationNo);
            if (teachers != null)
            {

                return View(teachers);
            }
            return View();
        }

        // GET: TeacherProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeacherProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherProfile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeacherProfile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeacherProfile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
