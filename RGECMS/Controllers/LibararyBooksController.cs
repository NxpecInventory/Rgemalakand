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
using PagedList;
using System.Diagnostics;

namespace RGECMS.Controllers
{
    public class LibararyBooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       public static LibarayIssuedBooks LibarayIssuedBooks { get; set; }

        // GET: LibararyBooks
        public ActionResult Index (string search, int? page)
        {
            var libararyBooks = db.LibararyBooks.Include(l => l.LibararyDepCat).ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                page = 1;
                //this is for call no
                libararyBooks =  db.LibararyBooks.Where(a => a.CallNo == search).ToList();
 
             
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
           
            return View( libararyBooks.OrderByDescending(m => m.AddedDate).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult IndexTitle(string searchtitle, int? page)
        {
            var libararyBooks = db.LibararyBooks.Include(l => l.LibararyDepCat).ToList();
            if (!string.IsNullOrWhiteSpace(searchtitle))
            {
                page = 1;
                //this is for Title 
          
                libararyBooks = db.LibararyBooks.Where(a => a.Title == searchtitle).ToList();
     

            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);

            return View(libararyBooks.OrderByDescending(m => m.AddedDate).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult IndexDepart(string searchdep, int? page)
        {
            var libararyBooks = db.LibararyBooks.Include(l => l.LibararyDepCat).ToList();
            if (!string.IsNullOrWhiteSpace(searchdep))
            {
                page = 1;
                //this is for Department
       
                libararyBooks = db.LibararyBooks.Where(a => a.LibararyDepCat.DepartmentName == searchdep).ToList();

            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);

            return View(libararyBooks.OrderByDescending(m => m.AddedDate).ToPagedList(pageNumber, pageSize));
        }

        // GET: LibararyBooks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibararyBooks libararyBooks = await db.LibararyBooks.FindAsync(id);
            if (libararyBooks == null)
            {
                return HttpNotFound();
            }
            return View(libararyBooks);
        }

        // GET: LibararyBooks/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.LibararyDepCat, "Id", "DepartmentName");
            ViewBag.Shelf = new SelectList(db.LibarayShelfCat, "Id", "ShelfName");
            return View();
        }

        // POST: LibararyBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LibararyBooks libararyBooks)
        {
            if (ModelState.IsValid)
            {
                int shelfcatno = Convert.ToInt32(libararyBooks.Shelf);
                var shelf = db.LibarayShelfCat.Where(a => a.Id ==shelfcatno ).Select(a =>a.ShelfName).FirstOrDefault();
                libararyBooks.Shelf = shelf;
                db.LibararyBooks.Add(libararyBooks);


                await db.SaveChangesAsync();
                TempData["msg"] = "Book " + libararyBooks.Title + " Added Succesfully to RGE Libraray Management System";
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.LibararyDepCat, "Id", "DepartmentName", libararyBooks.DepartmentId);
            ViewBag.Shelf = new SelectList(db.LibarayShelfCat, "Id", "ShelfName", libararyBooks.Shelf);
            return View(libararyBooks);
        }

        // GET: LibararyBooks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibararyBooks libararyBooks = await db.LibararyBooks.FindAsync(id);
            if (libararyBooks == null)
            {
                return HttpNotFound();
            }
            ViewBag.Shelf = new SelectList(db.LibarayShelfCat, "Id", "ShelfName", libararyBooks.Shelf);
            ViewBag.DepartmentId = new SelectList(db.LibararyDepCat, "Id", "DepartmentName", libararyBooks.DepartmentId);
            return View(libararyBooks);
        }

        // POST: LibararyBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LibararyBooks libararyBooks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libararyBooks).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["msg"] = "Book " + libararyBooks.Title + " Records Succesfully Updated By RGE Libraray Management System";
                return RedirectToAction("Index");
            }
            ViewBag.Shelf = new SelectList(db.LibarayShelfCat, "Id", "ShelfName", libararyBooks.Shelf);
            ViewBag.DepartmentId = new SelectList(db.LibararyDepCat, "Id", "DepartmentName", libararyBooks.DepartmentId);
            return View(libararyBooks);
        }

        // GET: LibararyBooks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibararyBooks libararyBooks = await db.LibararyBooks.FindAsync(id);
            if (libararyBooks == null)
            {
                return HttpNotFound();
            }
            return View(libararyBooks);
        }

        // POST: LibararyBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LibararyBooks libararyBooks = await db.LibararyBooks.FindAsync(id);
            db.LibararyBooks.Remove(libararyBooks);
            await db.SaveChangesAsync();
            TempData["msg"] = "Book " + libararyBooks.Title + "  Succesfully Deleted From RGE Library Management System";
            return RedirectToAction("Index");
        }

        //here assigning actions starts
        public async Task< ActionResult> Assign(int? id)
        {
            LibararyBooks libararyBooks = await db.LibararyBooks.FindAsync(id);
            if (libararyBooks.Quantity == 0)
            {
                TempData["msgnot"] = "Not Available! Cannot Issue Book"+" " + libararyBooks.Title +" " +"it Is Not Avialable in The Library!";
                return RedirectToAction("Index");
            }
            LibarayIssuedBooks = new LibarayIssuedBooks
            {
                BookId = libararyBooks.Id,
                BookTitle = libararyBooks.Title,
                AssignedBy = User.Identity.Name,
                AssignedDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(14),
                StudedRegId = 0,
                StudentName = "",
                StudentClass = "",
                StudentDepartment = "",
                Id = 0,
                Comments = "N/A",
                fineComment="",
                fineslipid="",
                finestatus="",
                Receiveddate=DateTime.Today,
                ReceivedStatus="Not Received",
                
                
            };



            return View(LibarayIssuedBooks);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Assign(LibarayIssuedBooks libarayIssuedBook)
        {
            //check for book availability
            //check for student id
            if (libarayIssuedBook.StudedRegId==0)
            {
                TempData["idnot"] = "Please Enter The Student Id To Issue The Library Book";
                return View(libarayIssuedBook);
            }
            //now check that the student id exists or not [check]
            Students checkstudent = await db.students.FindAsync(libarayIssuedBook.StudedRegId);
            if (checkstudent == null)
            {
                TempData["idnot"] = "Student Not Found! Please Provide The Valid Student Id";
                return View(libarayIssuedBook);
            }
            libarayIssuedBook.StudedRegId = checkstudent.Id;

           // LibarayIssuedBooks.StudentName = checkstudent.StudentName;
          
            //bind program and class of the student 
            var getprogram = db.programs.Where(a => a.Id == checkstudent.ProgramId).FirstOrDefault();

            var getclass = db.classes.Where(a => a.Id == checkstudent.ClassId).FirstOrDefault();
            //now bind this infor with model
            libarayIssuedBook.StudentDepartment = getprogram.ProgramName;
            libarayIssuedBook.StudentClass = getclass.ClassName;
            if (LibarayIssuedBooks.Comments == null)
            {
                libarayIssuedBook.Comments = "N/A";
            }

            LibarayIssuedBooks = libarayIssuedBook;
         
            return RedirectToAction("ConfirmAssign");
        }
        public  async Task<  ActionResult> ConfirmAssign()
        {
           
            try
            {
              
                db.LibarayIssuedBooks.Add(LibarayIssuedBooks);
                await db.SaveChangesAsync();
                return View(LibarayIssuedBooks);
            }
            catch (Exception ex) {
                Debug.Write(ex.Message);
            }

            return View(LibarayIssuedBooks);
            /*RedirectToAction("PrintSlip");*/
        }
        public async Task<ActionResult> SaveAndPrint(int? id)
        {
            //check the relevant saved issued record retrieve and display
            var checkrecord = await db.LibarayIssuedBooks.FindAsync(id);
            if (checkrecord.BookId != 0)
            {
                LibararyBooks libararyBooks = await db.LibararyBooks.FindAsync(checkrecord.BookId);
                libararyBooks.Quantity = libararyBooks.Quantity - 1;

                db.Entry(libararyBooks).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("PrintSlip");
            }

            ViewBag.msgnobook = "Book Stock Is Not Available";
            return View();
        }
        public ActionResult PrintSlip( )
        {
            return View(LibarayIssuedBooks);
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
