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
namespace RGECMS.Controllers
{
    public class CollegeEmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CollegeEmployees
        public ActionResult Index(string search, int? page)
        {
            var collegeEmployees = db.CollegeEmployees.Include(c => c.employeeDesignationCategory).ToList();

            if (!string.IsNullOrWhiteSpace(search))
            {
                int convertsearch = Convert.ToInt32(search);
                page = 1;
                collegeEmployees = collegeEmployees.Where(m => m.Id == convertsearch).ToList();
                TempData["Totaluser"] = collegeEmployees.Count();
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                TempData["Totaluser"] = collegeEmployees.Count();
            }
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View( collegeEmployees.OrderByDescending(m => m.JoiningDate).ToPagedList(pageNumber, pageSize));
        }

        // GET: CollegeEmployees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollegeEmployees collegeEmployees = await db.CollegeEmployees.FindAsync(id);
            if (collegeEmployees == null)
            {
                return HttpNotFound();
            }
            int d =collegeEmployees.DesignationId;
          string desname = db.employeeDesignationCategory.Where(m => m.Id == d).Select(m => m.DesignationName).FirstOrDefault();

            TempData["DesignationEmployee"] = desname;
            return View(collegeEmployees);
        }

        // GET: CollegeEmployees/Create
        public ActionResult Create()
        {
            ViewBag.DesignationId = new SelectList(db.employeeDesignationCategory, "Id", "DesignationName");
            return View();
        }

        // POST: CollegeEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,EmployeeName,FatherName,Address,ContactInfo,Status,JoiningDate,DesignationId")] CollegeEmployees collegeEmployees)
        {
            if (ModelState.IsValid)
            {
                db.CollegeEmployees.Add(collegeEmployees);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DesignationId = new SelectList(db.employeeDesignationCategory, "Id", "DesignationName", collegeEmployees.DesignationId);
            return View(collegeEmployees);
        }

        // GET: CollegeEmployees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollegeEmployees collegeEmployees = await db.CollegeEmployees.FindAsync(id);
            if (collegeEmployees == null)
            {
                return HttpNotFound();
            }
            ViewBag.DesignationId = new SelectList(db.employeeDesignationCategory, "Id", "DesignationName", collegeEmployees.DesignationId);
            return View(collegeEmployees);
        }

        // POST: CollegeEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,EmployeeName,FatherName,Address,ContactInfo,Status,JoiningDate,DesignationId")] CollegeEmployees collegeEmployees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collegeEmployees).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DesignationId = new SelectList(db.employeeDesignationCategory, "Id", "DesignationName", collegeEmployees.DesignationId);
            return View(collegeEmployees);
        }

        // GET: CollegeEmployees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollegeEmployees collegeEmployees = await db.CollegeEmployees.FindAsync(id);
            if (collegeEmployees == null)
            {
                return HttpNotFound();
            }
            return View(collegeEmployees);
        }

        // POST: CollegeEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CollegeEmployees collegeEmployees = await db.CollegeEmployees.FindAsync(id);
            db.CollegeEmployees.Remove(collegeEmployees);
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
