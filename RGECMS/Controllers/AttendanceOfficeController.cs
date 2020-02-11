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
    public class AttendanceOfficeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext
             ().GetUserManager<ApplicationUserManager>().FindById
             (System.Web.HttpContext.Current.User.Identity.GetUserId());
        // GET: AttendanceOffice
        public ActionResult AttendanceProfile()
        {


            CollegeEmployees employee = db.CollegeEmployees.Find(user.RegistrationNo);
            if (employee != null)
            {
                var getdesig = (from alias in db.CollegeEmployees where alias.Id == user.RegistrationNo select alias.DesignationId).FirstOrDefault();
                var getname = (from alias in db.employeeDesignationCategory where alias.Id == getdesig select alias.DesignationName).FirstOrDefault();
                TempData["name"] = getname;

                return View(employee);
            }
            return View();

        }


        // GET: AttendanceOffice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AttendanceOffice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AttendanceOffice/Create
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

        // GET: AttendanceOffice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AttendanceOffice/Edit/5
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

        // GET: AttendanceOffice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AttendanceOffice/Delete/5
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
