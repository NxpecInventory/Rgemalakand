using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using RGECMS.Models;
using Microsoft.AspNet.Identity;
using PagedList;
namespace RGECMS.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();




        // GET: ApplicationUsers
        public ActionResult Index(string search, int? page)
        {
          
            var users = db.Users.ToList();

            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;


                users = users.Where(m => m.RegistrationNo == convertsearch).ToList();
                TempData["Totaluser"] = users.Count();

            }
            TempData["Totaluser"] = users.Count();
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(users.OrderBy(m => m.RegistrationNo).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var context = new Models.ApplicationDbContext();
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            var context = new Models.ApplicationDbContext();
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            
            context.Users.Remove(user);
            context.SaveChanges();
            TempData["delmsg"] = "User Is Deleted SuccessFully!";
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
