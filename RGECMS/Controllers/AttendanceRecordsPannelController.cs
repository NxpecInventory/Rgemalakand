using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RGECMS.Models;
using PagedList;

namespace RGECMS.Controllers
{
    public class AttendanceRecordsPannelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AttendanceRecordsPannel

        public ActionResult Index(string search,int?page)
        {
            
            var attendancerecords = db.attendancerecords.Include(a => a.Attendanceoptions);
            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                attendancerecords = attendancerecords.Where(m => m.Studentid == convertsearch);
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(attendancerecords.OrderByDescending(m=>m.dataofattendance).ToList().ToPagedList(pageNumber,pageSize));
        }

        // GET: AttendanceRecordsPannel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceRecordsdata attendanceRecordsdata = db.attendancerecords.Find(id);
            if (attendanceRecordsdata == null)
            {
                return HttpNotFound();
            }
            return View(attendanceRecordsdata);
        }


     

        // GET: AttendanceRecordsPannel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceRecordsdata attendanceRecordsdata = db.attendancerecords.Find(id);
            if (attendanceRecordsdata == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.options, "Id", "Options", attendanceRecordsdata.StatusId);
            return View(attendanceRecordsdata);
        }

        // POST: AttendanceRecordsPannel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Studentid,Name,ClassId,Classname,dataofattendance,StatusId,Remarks")] AttendanceRecordsdata attendanceRecordsdata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendanceRecordsdata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.options, "Id", "Options", attendanceRecordsdata.StatusId);
            return View(attendanceRecordsdata);
        }

        // GET: AttendanceRecordsPannel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceRecordsdata attendanceRecordsdata = db.attendancerecords.Find(id);
            if (attendanceRecordsdata == null)
            {
                return HttpNotFound();
            }
            return View(attendanceRecordsdata);
        }

        // POST: AttendanceRecordsPannel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttendanceRecordsdata attendanceRecordsdata = db.attendancerecords.Find(id);
            db.attendancerecords.Remove(attendanceRecordsdata);
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
