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
    public class RegistrationOfficeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext
             ().GetUserManager<ApplicationUserManager>().FindById
             (System.Web.HttpContext.Current.User.Identity.GetUserId());
        public ActionResult ProfileRegistration()
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

        // GET: RegistrationOffice/Details/5
      
    }
}
