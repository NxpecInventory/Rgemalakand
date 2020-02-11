using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;
using System.Linq;
using RGECMS.Models;
using System.Web.Mvc;

namespace RGECMS
{
 
    public class Registrationactionsclass
    {
        private ApplicationDbContext db = new ApplicationDbContext();
      public  static bool confirmclose ()
        {
            bool msg = false;
            ApplicationDbContext db = new ApplicationDbContext();
            var checkalreadyempty = (from alias in db.StudentClassAssigningSystem select alias).FirstOrDefault();
            if (checkalreadyempty != null)
            {
                try {
                    db.StudentClassAssigningSystem.RemoveRange(db.StudentClassAssigningSystem);//deleting all the records 
                    db.SaveChanges();
                    msg = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Opps you have perform and invalid operation during registration controlling section");
                }
            }
            return msg;
        }
        //here second method 
        public static string checkopenorclose()
        {
            string msg = "null";
            ApplicationDbContext db = new ApplicationDbContext();
            var checkalreadyempty = (from alias in db.Registrationcontrolling select alias).FirstOrDefault();
            if (checkalreadyempty != null)
            {
                regclosingcat regclosingcat = db.regclosingcat.Find(checkalreadyempty.regclosingid);
               if(regclosingcat.RegOptions == "Open New Registrations")
                {
                    return msg = "New";
                }
                if (regclosingcat.RegOptions == "Close Registrations")
                {
                    return msg = "Close";
                }
                if (regclosingcat.RegOptions == "Open Registrations")
                {
                    return msg = "Open";
                }


            }
                return msg ;
        }
    }
}