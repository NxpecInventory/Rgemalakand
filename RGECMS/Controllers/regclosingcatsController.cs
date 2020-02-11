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
    public class regclosingcatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: regclosingcats
        public ActionResult Index()
        {
            return View(db.regclosingcat.ToList());
        }

        // GET: regclosingcats/Details/5 becuase i donot need this
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    regclosingcat regclosingcat = db.regclosingcat.Find(id);
        //    if (regclosingcat == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(regclosingcat);
        //}

        // GET: regclosingcats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: regclosingcats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegOptions")] regclosingcat regclosingcat)
        {
            if (ModelState.IsValid)
            {
                db.regclosingcat.Add(regclosingcat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(regclosingcat);
        }

        // GET: regclosingcats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regclosingcat regclosingcat = db.regclosingcat.Find(id);
            if (regclosingcat == null)
            {
                return HttpNotFound();
            }
            return View(regclosingcat);
        }

        // POST: regclosingcats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegOptions")] regclosingcat regclosingcat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regclosingcat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(regclosingcat);
        }

        // GET: regclosingcats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regclosingcat regclosingcat = db.regclosingcat.Find(id);
            if (regclosingcat == null)
            {
                return HttpNotFound();
            }
            return View(regclosingcat);
        }

        // POST: regclosingcats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            regclosingcat regclosingcat = db.regclosingcat.Find(id);
            db.regclosingcat.Remove(regclosingcat);
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
