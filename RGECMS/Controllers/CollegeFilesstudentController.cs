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
    public class CollegeFilesstudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
      private  ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext
            ().GetUserManager<ApplicationUserManager>().FindById
            (System.Web.HttpContext.Current.User.Identity.GetUserId());
        // GET: CollegeFiles
        public ActionResult Index()
        {
            var getspecific = db.CollegeFiles.ToList();
            getspecific.OrderByDescending(a => a.UploadingDate);
            return View(getspecific);
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
