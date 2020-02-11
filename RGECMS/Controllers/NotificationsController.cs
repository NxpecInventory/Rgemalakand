using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RGECMS.Models;
using Microsoft.AspNet.Identity.Owin;


namespace RGECMS.Controllers
{
    public class NotificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationRoleManager _roleManager;
        //public NotificationsController(ApplicationRoleManager roleManager)
        //{
          
        //    RoleManager = roleManager;

        //}
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        // GET: Notifications
        public ActionResult Index()
        {
            string checkeachresult=null;
            if (User.IsInRole("Teacher"))
            {
                var notstudent = db.Notification.Where(a => a.NotificationSpecific == "Teacher"&&a.status!="Read").ToList();
                notstudent = notstudent.OrderByDescending(a => a.NotificationDate).ToList();
                if (notstudent.Count > 0)
                {
                    checkeachresult = "yes";
                }
                else
                {
                    checkeachresult = null;
                }
                TempData["chck"] = checkeachresult;
                return View(notstudent);
               
            }
            if (User.IsInRole("Student"))
            {
                var notstudent = db.Notification.Where(a => a.NotificationSpecific == "Student" && a.status != "Read").ToList();
                notstudent = notstudent.OrderByDescending(a => a.NotificationDate).ToList();
                if (notstudent.Count > 0)
                {
                    checkeachresult = "yes";
                }
                else
                {
                    checkeachresult = null;
                }
                TempData["chck"] = checkeachresult;
                return View(notstudent);
            }
            if (User.IsInRole("Accounts"))
            {
                var notstudent = db.Notification.Where(a => a.NotificationSpecific == "Accounts" && a.status != "Read").ToList();
                notstudent = notstudent.OrderByDescending(a => a.NotificationDate).ToList();
                if (notstudent.Count > 0)
                {
                    checkeachresult = "yes";
                }
                else
                {
                    checkeachresult = null;
                }
                TempData["chck"] = checkeachresult;
                return View(notstudent);
            }
            if (User.IsInRole("AttendanceOffice"))
            {
                var notstudent = db.Notification.Where(a => a.NotificationSpecific == "AttendanceOffice" && a.status != "Read").ToList();
                notstudent = notstudent.OrderByDescending(a => a.NotificationDate).ToList();
                if (notstudent.Count > 0)
                {
                    checkeachresult = "yes";
                }
                else
                {
                    checkeachresult = null;
                }
                TempData["chck"] = checkeachresult;
                return View(notstudent);
            }
            if (User.IsInRole("RegistrationOffice"))
            {
                var notstudent = db.Notification.Where(a => a.NotificationSpecific == "RegistrationOffice" && a.status != "Read").ToList();
                notstudent = notstudent.OrderByDescending(a => a.NotificationDate).ToList();
                if (notstudent.Count > 0)
                {
                    checkeachresult = "yes";
                }
                else
                {
                    checkeachresult = null;
                }
                TempData["chck"] = checkeachresult;
                return View(notstudent);
               
            }

            var not = db.Notification.ToList();
            not = not.OrderByDescending(a => a.NotificationDate).ToList();
            if (not.Count > 0)
            {
                checkeachresult = "yes";
            }
            TempData["chck"] = checkeachresult;
            return View(not);
        }

        // View Previus Notific\tions
        public ActionResult Previuos()
        {
            if (User.IsInRole("Teacher"))
            {
                var notstudent = db.Notification.Where(a => a.NotificationSpecific == "Teacher" && a.status == "Read").ToList();
                notstudent = notstudent.OrderByDescending(a => a.NotificationDate).ToList();
                return View(notstudent);
            }
            if (User.IsInRole("Student"))
            {
                var notstudent = db.Notification.Where(a => a.NotificationSpecific == "Student" && a.status == "Read").ToList();
                notstudent = notstudent.OrderByDescending(a => a.NotificationDate).ToList();
                return View(notstudent);
            }
            if (User.IsInRole("Accounts"))
            {
                var notstudent = db.Notification.Where(a => a.NotificationSpecific == "Accounts" && a.status == "Read").ToList();
                notstudent = notstudent.OrderByDescending(a => a.NotificationDate).ToList();
                return View(notstudent);
            }
            if (User.IsInRole("AttendanceOffice"))
            {
                var notstudent = db.Notification.Where(a => a.NotificationSpecific == "AttendanceOffice" && a.status != "Read").ToList();
                notstudent = notstudent.OrderByDescending(a => a.NotificationDate).ToList();
                return View(notstudent);
            }
            if (User.IsInRole("RegistrationOffice"))
            {
                var notstudent = db.Notification.Where(a => a.NotificationSpecific == "RegistrationOffice" && a.status == "Read").ToList();
                notstudent = notstudent.OrderByDescending(a => a.NotificationDate).ToList();
                return View(notstudent);
            }

            var not = db.Notification.ToList();
            not = not.OrderByDescending(a => a.NotificationDate).ToList();
            return View(not);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification notification = db.Notification.Find(id);

            if (notification == null)
            {
                return HttpNotFound();
            }
            notification.status = "Read";
            db.Entry(notification).State = EntityState.Modified;
            db.SaveChanges();
            Notification notificationupdated = db.Notification.Find(id);
            return View(notificationupdated);
        }

        // GET: Notifications/Create
        public ActionResult Create()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var roles in RoleManager.Roles)
                list.Add(new SelectListItem() { Value = roles.Name, Text = roles.Name });
            ViewBag.RolesList = list;
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NotificationMessage,NotificationDate,NotificationSpecific,NotificationAll,status")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                notification.status = "Unread";
                if (notification.NotificationAll == null)
                {
                    notification.NotificationAll = "No";
                }
                db.Notification.Add(notification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<SelectListItem> list = new List<SelectListItem>();
            // If we got this far, something failed, redisplay form
            foreach (var roles in RoleManager.Roles)
                list.Add(new SelectListItem() { Value = roles.Name, Text = roles.Name });
            ViewBag.RolesList = list;
            return View(notification);
        }

       

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    

        // GET: Notifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification notification = db.Notification.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notification notification = db.Notification.Find(id);
            db.Notification.Remove(notification);
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
