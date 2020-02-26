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
    public class TeacherAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext
            ().GetUserManager<ApplicationUserManager>().FindById
            (System.Web.HttpContext.Current.User.Identity.GetUserId());
        // GET: TeacherAccount
        public ActionResult ProfileTeacher()
        {
           Teachers Teacher = db.Teachers.Find(user.RegistrationNo);
            if (Teacher != null)
            { //here problem designation solved 

             
                return View(Teacher);
            }
            return View();
        }

        // GET: TeacherAccount/salary
        public ActionResult TeacherSalaryRecords()
        {
            var salaryRecords = (from alias in db.TeacherSalaryRecords where alias.TeacherId == user.RegistrationNo select alias).ToList();
            salaryRecords.OrderByDescending(a=>a.SubmissionDate);
            TempData["Countt"] = salaryRecords.Count();
            return View(salaryRecords);
        }

        // GET: TeacherAccount/Create
        public ActionResult AssignedSubjects()
        {

            var salaryRecords = (from alias in db.TeacherCoursesRecord where alias.Teacherid == user.RegistrationNo && alias.AssignedDate.Year==DateTime.Now.Year select alias).ToList();
            salaryRecords.OrderByDescending(a => a.AssignedDate);
            TempData["Counttt"] = salaryRecords.Count();
            return View(salaryRecords);
        }
        public ActionResult PreviousAssignedSubjects()
        {

            var salaryRecords = (from alias in db.TeacherCoursesRecord where alias.Teacherid == user.RegistrationNo && alias.AssignedDate.Year < DateTime.Now.Year select alias).ToList();
            salaryRecords.OrderByDescending(a => a.AssignedDate);
            TempData["Countp"] = salaryRecords.Count();
            return View(salaryRecords);
        }
        public ActionResult Details(int? id)
        {
            TeacherCoursesRecord detail= db.TeacherCoursesRecord.Find(id);
            return View(detail);

        }


    }
}
