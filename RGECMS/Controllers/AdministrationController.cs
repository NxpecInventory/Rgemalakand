using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RGECMS.Models;

namespace RGECMS.Controllers
{
    public class AdministrationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext
            ().GetUserManager<ApplicationUserManager>().FindById
            (System.Web.HttpContext.Current.User.Identity.GetUserId());
        public ActionResult AdminProfile()
        {
            CollegeEmployees employee = db.CollegeEmployees.Find(user.RegistrationNo);
            if (employee != null)
            { //here problem designation solved 
                var getdesig = (from alias in db.CollegeEmployees where alias.Id == user.RegistrationNo select alias.DesignationId).FirstOrDefault();
                var getname = (from alias in db.employeeDesignationCategory where alias.Id == getdesig select alias.DesignationName).FirstOrDefault();
                TempData["name"] = getname;
                return View(employee);
            }
            return View(employee);
        }

        // GET: Administration/Details/5
      
    }
}
