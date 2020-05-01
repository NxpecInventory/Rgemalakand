using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RGECMS.Models;

namespace RGECMS.Controllers
{
    public class LibarayIssuedBooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LibarayIssuedBooks
        public async Task<ActionResult> Index()
        {
         
            return View(await db.LibarayIssuedBooks.ToListAsync());
      

        }

        // GET: LibarayIssuedBooks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibarayIssuedBooks libarayIssuedBooks = await db.LibarayIssuedBooks.FindAsync(id);
            if (libarayIssuedBooks == null)
            {
                return HttpNotFound();
            }
            return View(libarayIssuedBooks);
        }

        // GET: LibarayIssuedBooks/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: LibarayIssuedBooks/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,BookTitle,BookId,AssignedBy,AssignedDate,ReturnDate,StudedRegId,StudentName,StudentDepartment,StudentClass,Comments,fineComment,ReceivedStatus,Receiveddate,fineslipid,finestatus")] LibarayIssuedBooks libarayIssuedBooks)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.LibarayIssuedBooks.Add(libarayIssuedBooks);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(libarayIssuedBooks);
        //}

        // GET: LibarayIssuedBooks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibarayIssuedBooks libarayIssuedBooks = await db.LibarayIssuedBooks.FindAsync(id);
            if (libarayIssuedBooks == null)
            {
                return HttpNotFound();
            }
            return View(libarayIssuedBooks);
        }

        // POST: LibarayIssuedBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,BookTitle,BookId,AssignedBy,AssignedDate,ReturnDate,StudedRegId,StudentName,StudentDepartment,StudentClass,Comments,fineComment,ReceivedStatus,Receiveddate,fineslipid,finestatus")] LibarayIssuedBooks libarayIssuedBooks)
        {
            if (ModelState.IsValid)
            {

                //         public string fineComment { get; set; }
                //public string ReceivedStatus { get; set; }
                //public DateTime Receiveddate { get; set; }
                //public string fineslipid { get; set; }
                //public string finestatus { get; set; }
                libarayIssuedBooks.Receiveddate = DateTime.Now;
                if (libarayIssuedBooks.ReturnDate > libarayIssuedBooks.ReturnDate)
                {
                    if (libarayIssuedBooks.fineslipid == "")
                    {
                        ViewBag.finemsg = "Provide the Fine Challan ID to Proceed.";
                        return View(libarayIssuedBooks);
                    }
                    int convert =Convert.ToInt32(libarayIssuedBooks.fineslipid);
                    Finerecords checkrecord = await db.Finerecords.FindAsync(convert);
                    if (checkrecord == null)
                    {
                        ViewBag.finemsg = "Provided  Fine Challan ID Not Matched.";
                    }
                        libarayIssuedBooks.finestatus = "Fined";
                }
                else { libarayIssuedBooks.finestatus = "Not Fined"; }
                libarayIssuedBooks.ReceivedStatus = "Received";
               
                db.Entry(libarayIssuedBooks).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(libarayIssuedBooks);
        }

        // GET: LibarayIssuedBooks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibarayIssuedBooks libarayIssuedBooks = await db.LibarayIssuedBooks.FindAsync(id);
            if (libarayIssuedBooks == null)
            {
                return HttpNotFound();
            }
            return View(libarayIssuedBooks);
        }

        // POST: LibarayIssuedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LibarayIssuedBooks libarayIssuedBooks = await db.LibarayIssuedBooks.FindAsync(id);
            db.LibarayIssuedBooks.Remove(libarayIssuedBooks);
            await db.SaveChangesAsync();
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
