using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RGECMS.Controllers
{
   
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
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