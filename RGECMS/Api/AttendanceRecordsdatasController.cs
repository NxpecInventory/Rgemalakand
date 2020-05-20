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
    public class AttendanceRecordsdatasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AttendanceRecordsdatas
        public IQueryable<AttendanceRecordsdata> Getattendancerecords()
        {
            return db.attendancerecords;
        }

        // GET: api/AttendanceRecordsdatas/5
        [ResponseType(typeof(AttendanceRecordsdata))]
        public IHttpActionResult GetAttendanceRecordsdata(int id)
        {
            AttendanceRecordsdata attendanceRecordsdata = db.attendancerecords.Find(id);
            if (attendanceRecordsdata == null)
            {
                return NotFound();
            }

            return Ok(attendanceRecordsdata);
        }

        // PUT: api/AttendanceRecordsdatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAttendanceRecordsdata(int id, AttendanceRecordsdata attendanceRecordsdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attendanceRecordsdata.Id)
            {
                return BadRequest();
            }

            db.Entry(attendanceRecordsdata).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceRecordsdataExists(id))
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

        // POST: api/AttendanceRecordsdatas
        [ResponseType(typeof(AttendanceRecordsdata))]
        public IHttpActionResult PostAttendanceRecordsdata(AttendanceRecordsdata attendanceRecordsdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.attendancerecords.Add(attendanceRecordsdata);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = attendanceRecordsdata.Id }, attendanceRecordsdata);
        }

        // DELETE: api/AttendanceRecordsdatas/5
        [ResponseType(typeof(AttendanceRecordsdata))]
        public IHttpActionResult DeleteAttendanceRecordsdata(int id)
        {
            AttendanceRecordsdata attendanceRecordsdata = db.attendancerecords.Find(id);
            if (attendanceRecordsdata == null)
            {
                return NotFound();
            }

            db.attendancerecords.Remove(attendanceRecordsdata);
            db.SaveChanges();

            return Ok(attendanceRecordsdata);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttendanceRecordsdataExists(int id)
        {
            return db.attendancerecords.Count(e => e.Id == id) > 0;
        }
    }
}