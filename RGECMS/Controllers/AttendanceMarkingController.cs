using RGECMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RGECMS.Controllers
{
    public class AttendanceMarkingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: AttendanceMarking
        public ActionResult MarkAttendance()
        {
            ViewBag.ClassId = new SelectList(db.classes, "Id", "ClassName");


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MarkAttendance(AttendanceViewModel attendancevm)
        {
            //    TempData["date"] = collection["dataofattendance"]
            if (ModelState.IsValid)
            { TempData["Classid"] =attendancevm.ClassId;
                TempData["date"] = attendancevm.Date;
               return RedirectToAction("AttendanceSheet", "AttendanceMarking");
            }

            ViewBag.ClassId = new SelectList(db.classes, "Id", "ClassName",attendancevm.ClassId);
            return View(attendancevm);



        }

        // GET: AttendanceMarking/Createz
        public ActionResult AttendanceSheet()
        {
            ViewBag.ClassId = TempData["Classid"];
            int classid = ViewBag.ClassId;
            DateTime date = Convert.ToDateTime(TempData["date"]);
            int attendancestatus = (from x in db.options where x.Options == "Present" select x.Id).FirstOrDefault();
           string  classname = (from x in db.classes where x.Id == classid select x.ClassName).FirstOrDefault();

            AttendanceRecordsdata attendance = new AttendanceRecordsdata();
            List<int> attendanceids = new List<int>();

            var students = (from x in db.students where x.ClassId == classid select x).ToList();
            //List<int> recordsids = new List<int>();
            foreach (var i in students)
            {
                attendance.Classname = classname;
                attendance.ClassId = i.ClassId;
                attendance.Name = i.StudentName;
                attendance.Studentid = i.Id;
                attendance.dataofattendance = date;
                attendance.Remarks = "";
                attendance.StatusId = attendancestatus;
                db.attendancerecords.Add(attendance);
                db.SaveChanges();
                db.Entry(attendance).GetDatabaseValues();// getting recent value of the entity
                attendanceids.Add(attendance.Id);//here i am inserting each attendance record primary key to the list for attendance sheet
          
            }
            TempData["Class"] = classid;
            TempData["ListIds"] = attendanceids;
         
            return RedirectToAction("Index", "AttendanceRecordsdatas");
        }
    }
}
