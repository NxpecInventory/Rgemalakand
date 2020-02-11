using RGECMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net;

namespace RGECMS.Controllers
{
    [Authorize]
    public class UserAccountDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext
            ().GetUserManager<ApplicationUserManager>().FindById
            (System.Web.HttpContext.Current.User.Identity.GetUserId());
        // GET: UserAccountProfile
        public ActionResult UserProfile()
        {
      
            if (user!= null)
            {//here role based user identification starts
               
                if (System.Web.HttpContext.Current.User.IsInRole("Student"))// for rge students
                {
                    Students students = db.students.Find(user.RegistrationNo);
                    if (students != null)
                    {
                        return View (students);//student profile done (working properly)
                    }
                }//end students

                //if (System.Web.HttpContext.Current.User.IsInRole("Teacher"))// for rge teachers
                //{
                    
                //        //return RedirectToAction("TeacherProfile", "TeacherProfile");
                    
                //}//end teachers

                //if (System.Web.HttpContext.Current.User.IsInRole("Accounts"))// for rge collegeemployyes including accounts 
                //{ 
                //    CollegeEmployees employee = db.CollegeEmployees.Find(user.RegistrationNo); 
                //    if (employee != null)
                //    {
                //        var getdesig = (from alias in db.CollegeEmployees where alias.Id == user.RegistrationNo select alias.DesignationId).FirstOrDefault();
                //    var getname=(from alias in db.employeeDesignationCategory where alias.Id == getdesig select alias.DesignationName).FirstOrDefault();
                //        TempData["name"] = getname;

                //        return View(employee);
                //    }
                //}//end accounts


                //if (System.Web.HttpContext.Current.User.IsInRole("AttendanceOffice"))// attendance employyes
                //{
                //    CollegeEmployees employee = db.CollegeEmployees.Find(user.RegistrationNo);
                //    if (employee != null)
                //    {
                //        return View(employee);
                //    }
                //}//end accounts
            }
            return View("Opps there is some problem in Profile Information ");
        }

        // GET: UserAccountDetails/Details/5
        

        // GET: UserAccountDetails/Create
      
       

  // below action is for student fees records
        public ActionResult CollegeFeeRecords()
        {
            var FeeRecords = (from alias in db.StudentFeeRecords where alias.StudentId==user.RegistrationNo select alias).ToList();
            if(FeeRecords.Count==0)
            {
                TempData["Feerec"] = "Your Fees Record is Not Found!Because You Have Not Yet payed any Fee in Rahman Group Of Education College. ";
                return View(FeeRecords);
            }
            return View(FeeRecords);
        }
        // below action is for student fees records
        public ActionResult FineRecords()
        {
            var FineRecords = (from alias in db.Finerecords where alias.StudentId == user.RegistrationNo select alias).ToList();
            if (FineRecords.Count==0)
            {
                TempData["Finerec"] = "No Fine Record Found!Your are not been Charged Fine of Any Type in Rahman Group Of Education College. ";
                return View(FineRecords);
            }
     
            return View(FineRecords);
        }
        // from student courses buckets for all registration records 
        public ActionResult StudentCoursesbucket()
        {
            Students student = db.students.Find(user.RegistrationNo);
            var studentbucketrecords = (from alias in db.StudentCoursesBucket where alias.Studentid == user.RegistrationNo &&alias.ClassId!=student.ClassId select alias).ToList();
            if (studentbucketrecords.Count==0)// here i changed the check logic from null to list count 
            {
                TempData["bucketmsg"] = "No Class/Semester Record Found! Because You Have not yet Cleared Your first Semester/Class Newly In Rehman Group Of Education College.";
                return View(studentbucketrecords);
            }
            
            return View(studentbucketrecords);
        }
        public ActionResult StudentRecentReg()
        {
            Students student = db.students.Find(user.RegistrationNo);
            var studentbucketrecords = (from alias in db.StudentCoursesBucket where alias.Studentid == user.RegistrationNo && alias.ClassId== student.ClassId select alias).ToList();
            if (studentbucketrecords.Count==0)// here i changed the check logic from null to list count 
            {
                
                TempData["curmsg"] = "No Class/Semester Record Found! Because You Have You Have Taken a new Addmission In Rehman Group Of Education College.";
                return View(studentbucketrecords);
            }
            
            return View(studentbucketrecords);
        }
        public ActionResult AttendanceRecord(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var attendanceRecordsdata = (from alias in db.attendancerecords where alias.Studentid == user.RegistrationNo && alias.ClassId == id select alias).ToList();
            if (attendanceRecordsdata.Count==0)// here i changed the check logic from null to list count
            {
             TempData["attendancerec"] = "Attendance Record Not Found!(This Can be due to the attendance Is Not Yet Marked).";
                return View(attendanceRecordsdata);
            }
          
            return View(attendanceRecordsdata);
        
        }
        //here each class subject lists 
        public ActionResult SubjectRecord(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var subjectsRecordsdata = (from alias in db.subject.Include(s => s.Classes) where alias.ClassId == id select alias).ToList();
            if (subjectsRecordsdata.Count==0)// here i changed the check logic from null to list count
            {
               TempData["subject"] = "Subjects Record Not Found!(This Can be due to the No Subject Is Assigned to This Class Or Temporary Unavialable).";
                return View(subjectsRecordsdata);
            }
           
            return View(subjectsRecordsdata);

        }
        // this is done and working properly and tested
        //file lectures added
        public ActionResult UploadedFiles()
        {
            var getspecific = db.CollegeFiles.ToList();

            return View(getspecific);
        }
        public ActionResult Download(int? id)
        {
            var filesdata = (from alias in db.CollegeFiles where alias.Id == id select alias).FirstOrDefault();

            byte[] fileBytes = System.IO.File.ReadAllBytes(filesdata.filepath + filesdata.FileDescription);
       
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filesdata.FileDescription);
        
   

          
        }
    }
}
