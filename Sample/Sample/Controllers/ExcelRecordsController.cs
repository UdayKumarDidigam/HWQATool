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
using HWQATool.Models;
using Sample.Models;

namespace Sample.Controllers
{
    public class ExcelRecordsController : ApiController
    {
        private SampleContext db = new SampleContext();

        // GET api/ExcelRecords
        public IQueryable<ExcelRecord> GetExcelRecords()
        {
            return db.ExcelRecords;
        }

        // GET api/ExcelRecords/5
        [ResponseType(typeof(ExcelRecord))]
        public IHttpActionResult GetExcelRecord(long id)
        {
            ExcelRecord excelrecord = db.ExcelRecords.Find(id);
            if (excelrecord == null)
            {
                return NotFound();
            }

            return Ok(excelrecord);
        }

        // PUT api/ExcelRecords/5
        public IHttpActionResult PutExcelRecord(long id, ExcelRecord excelrecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != excelrecord.Id)
            {
                return BadRequest();
            }

            db.Entry(excelrecord).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExcelRecordExists(id))
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

        // POST api/ExcelRecords
        [ResponseType(typeof(ExcelRecord))]
        public IHttpActionResult PostExcelRecord(ExcelRecord excelrecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExcelRecords.Add(excelrecord);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = excelrecord.Id }, excelrecord);
        }

        // DELETE api/ExcelRecords/5
        [ResponseType(typeof(ExcelRecord))]
        public IHttpActionResult DeleteExcelRecord(long id)
        {
            ExcelRecord excelrecord = db.ExcelRecords.Find(id);
            if (excelrecord == null)
            {
                return NotFound();
            }

            db.ExcelRecords.Remove(excelrecord);
            db.SaveChanges();

            return Ok(excelrecord);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExcelRecordExists(long id)
        {
            return db.ExcelRecords.Count(e => e.Id == id) > 0;
        }
    }
}