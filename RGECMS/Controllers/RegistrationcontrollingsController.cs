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
    public class RegistrationcontrollingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       public static bool warningcheck = false;

        // GET: Registrationcontrollings
        public ActionResult Index()
        {
            var registrationcontrolling = db.Registrationcontrolling.Include(r => r.regclosingcat);
            return View(registrationcontrolling.ToList());
        }

        //// GET: Registrationcontrollings/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Registrationcontrolling registrationcontrolling = db.Registrationcontrolling.Find(id);
        //    if (registrationcontrolling == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(registrationcontrolling);
        //}

        // GET: Registrationcontrollings/ becuase no need to create new one
        //public ActionResult Create()
        //{
        //    ViewBag.regclosingid = new SelectList(db.regclosingcat, "Id", "RegOptions");
        //    return View();
        //}

        //// POST: Registrationcontrollings/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Comment,Updationdate,regclosingid")] Registrationcontrolling registrationcontrolling)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Registrationcontrolling.Add(registrationcontrolling);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.regclosingid = new SelectList(db.regclosingcat, "Id", "RegOptions", registrationcontrolling.regclosingid);
        //    return View(registrationcontrolling);
        //}

        // GET: Registrationcontrollings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrationcontrolling registrationcontrolling = db.Registrationcontrolling.Find(id);
            if (registrationcontrolling == null)
            {
                return HttpNotFound();
            }
            ViewBag.regclosingid = new SelectList(db.regclosingcat, "Id", "RegOptions", registrationcontrolling.regclosingid);
            return View(registrationcontrolling);
        }

        // POST: Registrationcontrollings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Comment,Updationdate,regclosingid")] Registrationcontrolling registrationcontrolling)
        {
            if (ModelState.IsValid)
            {
           
                regclosingcat regclosingcat = db.regclosingcat.Find(registrationcontrolling.regclosingid);
                if (regclosingcat.RegOptions == "Open New Registrations"&&warningcheck==true)
                {
                    Registrationactionsclass.confirmclose();
                }

                    if (warningcheck == false)
                {
                    if (regclosingcat.RegOptions == "Open New Registrations")
                    {
                        TempData["alert1"] = "new";
                        warningcheck = true;
                        ViewBag.regclosingid = new SelectList(db.regclosingcat, "Id", "RegOptions", registrationcontrolling.regclosingid);
                 
                        return View(registrationcontrolling);
                    }
                    if (regclosingcat.RegOptions == "Close Registrations")
                    {
                        TempData["alert2"] = "close";
                        warningcheck = true;
                        ViewBag.regclosingid = new SelectList(db.regclosingcat, "Id", "RegOptions", registrationcontrolling.regclosingid);
                        return View(registrationcontrolling);
                    }
                    if (regclosingcat.RegOptions == "Open Registrations")
                    {
                        TempData["alert3"] = "open";
                        warningcheck = true;
                        ViewBag.regclosingid = new SelectList(db.regclosingcat, "Id", "RegOptions", registrationcontrolling.regclosingid);
                        return View(registrationcontrolling);
                    }
                }
                else
                {

                    db.Entry(registrationcontrolling).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["status"] = "SuccessFully Updated The Registration Status";
                    warningcheck = false;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.regclosingid = new SelectList(db.regclosingcat, "Id", "RegOptions", registrationcontrolling.regclosingid);
            return View(registrationcontrolling);
        }

        //// GET: Registrationcontrollings/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Registrationcontrolling registrationcontrolling = db.Registrationcontrolling.Find(id);
        //    if (registrationcontrolling == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(registrationcontrolling);
        //}

        //// POST: Registrationcontrollings/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Registrationcontrolling registrationcontrolling = db.Registrationcontrolling.Find(id);
        //    db.Registrationcontrolling.Remove(registrationcontrolling);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
