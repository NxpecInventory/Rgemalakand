using RGECMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RGECMS.Controllers
{
   
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {

            TempData["Totaluser"] =  db.CollegeEmployees.Count();
            TempData["student"] = db.students.Count();



            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult EmployeeHome()
        {
            return View();
        }
      
        public ActionResult Accounts()
        {
            return View();
        }
        public ActionResult CourseHome()
        {
            return View();
        }
        public ActionResult AttendanceHome()
        {
            return View();
        }


    }
}