using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RGECMS.Models;

namespace RGECMS.Api
{
    public class StudentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Students
        public IEnumerable<Students> Getstudents()
        {
            return  db.students.ToList();
        }

        // GET: api/Students/5
        [ResponseType(typeof(Students))]
        public IHttpActionResult GetStudents(int id)
        {
            Students students = db.students.Find(id);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudents(int id, Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != students.Id)
            {
                return BadRequest();
            }

            db.Entry(students).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Students))]
        public IHttpActionResult PostStudents(Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(students).State = EntityState.Modified;
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = students.Id }, students);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Students))]
        public IHttpActionResult DeleteStudents(int id)
        {
            Students students = db.students.Find(id);
            if (students == null)
            {
                return NotFound();
            }

            db.students.Remove(students);
            db.SaveChanges();

            return Ok(students);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentsExists(int id)
        {
            return db.students.Count(e => e.Id == id) > 0;
        }
    }
}