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
    public class AttendanceRecordsdatasController : Controller
    {
        public static List<int> fornav = new List<int>();
        public static bool check = false;
        public static string classname;

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AttendanceRecordsdatas

        public ActionResult Index()
        {
            
            
            if (check==false)
            {
                try {
                   string id = TempData["Class"].ToString();
                    int classid = Convert.ToInt32(id);
                    var query = (from alias in db.classes where alias.Id == classid select alias.ClassName).FirstOrDefault();
                    classname = query;
                    List<int> ids = (List<int>)TempData["ListIds"];
                    TempData["classname"] = classname;
                    fornav = ids;
                    var usernormal = db.attendancerecords.Where(t => fornav.Contains(t.Id)).ToList();
                    var attendancerecordsnormal = usernormal;
                    TempData["found"] = ids.Count();
                    ViewBag.StatusId = new SelectList(db.options, "Id", "Options");
                    if (ids.Count==0)
                    {
                        TempData["notfound"] = "No Student Record Found In"+" "+classname+"! "+" It Can be due to No Student Is Registered In This Class/Semester Or You Have Provided In Correct Class/Semester";
                    }
                
                    return View(attendancerecordsnormal.ToList());
                }
                catch
                {

                    List<AttendanceRecordsdata> attendanceRecordsdata = db.attendancerecords.Where(t => fornav.Contains(t.Id)).ToList();
                    foreach (var i in attendanceRecordsdata)
                    {
                        db.attendancerecords.Remove(i);
                        db.SaveChanges();
                    }
                    //if  ERROR occurs delete the generated attendance sheet record of that rge college attendance and  REDIRECTING to main attendance page
                    check = false;
                    classname = null;
                    fornav.Clear();
                    TempData["failmesage"] = "An Error Occured in Doing The incorrect operation attendance record is not created please create again either during Attendance marking page is reloaded (please for solving this issue please do not reload the attendance sheet during Attendance Marking) or invalid operation/action performed";

                    return RedirectToAction("MarkAttendance", "AttendanceMarking");
                }
            }
            TempData["classname"] = classname;
            TempData["found"] = "Total Enrolled Student In Class/Semester:" + fornav.Count();
            var user = db.attendancerecords.Where(t => fornav.Contains(t.Id)).ToList();
            var attendancerecords = user;
            ViewBag.StatusId = new SelectList(db.options, "Id", "Options");
            return View(attendancerecords.ToList());


        }

        // GET: AttendanceRecordsdatas/Details/5
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
            if (attendanceRecordsdata != null)
            {
                check = true;
            }
            return View(attendanceRecordsdata);
        }

        // GET: AttendanceRecordsdatas/Create // commeted for a reason because in rge attendance am not using this action while taking attendance 
        //public ActionResult Create()
        //{
        //    ViewBag.StatusId = new SelectList(db.options, "Id", "Options");
        //    return View();
        //}

        //// POST: AttendanceRecordsdatas/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmMark()
        {
            check = false;
            classname = null;
            fornav.Clear();
            TempData["success"] =classname+" " +"Attendance Marked Sucessfully! You Can View the Attendance Records in the Attendance Records Pannel!";
          
            return RedirectToAction("MarkAttendance", "AttendanceMarking");
        }
        public ActionResult NotFound()
        {

            return RedirectToAction("MarkAttendance", "AttendanceMarking");
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AttendanceRecordsdata attendanceRecordsdata)
        {
            if (ModelState.IsValid)
            {
                if(attendanceRecordsdata.Remarks==null)
                {
                    attendanceRecordsdata.Remarks = "Marked";
                }
                check = true;
                db.Entry(attendanceRecordsdata).State = EntityState.Modified;
                db.SaveChanges();
              
                return RedirectToAction("Index");
            }
            check = true;
            ViewBag.StatusId = new SelectList(db.options, "Id", "Options", attendanceRecordsdata.StatusId);
            return View(attendanceRecordsdata);
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
