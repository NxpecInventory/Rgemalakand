using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RGECMS.Models;

namespace RGECMS.Controllers
{
    // completed final tested done!
    public class PublicmessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Publicmessages
        public ActionResult Index()
        {
            var orderquery = db.Publicmessages.ToList();
            orderquery = orderquery.OrderByDescending(a => a.MessageDate).ToList();
            return View(orderquery);
        }

        // GET: Publicmessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicmessages publicmessages = db.Publicmessages.Find(id);
            if (publicmessages == null)
            {
                return HttpNotFound();
               
            }
            if (publicmessages.status == "UnReaded")
            {
                publicmessages.status = "Readed";
                db.Entry(publicmessages).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View(publicmessages);
        }

        // GET: Publicmessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publicmessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Publicmessages publicmessages)
        {
            if (ModelState.IsValid)
            {
                publicmessages.MessageDate = DateTime.Now;
                publicmessages.status = "UnReaded";
                if (publicmessages.phoneno == null)
                {
                    publicmessages.phoneno = "Not Provided";
                }
                        db.Publicmessages.Add(publicmessages);
                db.SaveChanges();
                TempData["shownote"] = "Dear!" + " " + publicmessages.Fullname + " " + "Your Query/Message Is Delivered To Rehman Group Of Education College We will Reply You Soon About your Query Thank You For Contacting Us,Regards RGE College Administration";
                return View();
            }

            return View(publicmessages);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicmessages publicmessages = db.Publicmessages.Find(id);
            if (publicmessages == null)
            {
                return HttpNotFound();
            }
            return View(publicmessages);
        }

        // POST: Publicmessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publicmessages publicmessages = db.Publicmessages.Find(id);
            db.Publicmessages.Remove(publicmessages);
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
