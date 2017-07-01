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
    public class UploadTracksController : ApiController
    {
        private SampleContext db = new SampleContext();

        // GET api/UploadTracks
        public IQueryable<UploadTrack> GetUploadTracks()
        {
            return db.UploadTracks.Include("Team");
        }

        // GET api/UploadTracks/5
        [ResponseType(typeof(UploadTrack))]
        public IHttpActionResult GetUploadTrack(long id)
        {
            UploadTrack uploadtrack = db.UploadTracks.Find(id);
            if (uploadtrack == null)
            {
                return NotFound();
            }

            return Ok(uploadtrack);
        }

        // PUT api/UploadTracks/5
        public IHttpActionResult PutUploadTrack(long id, UploadTrack uploadtrack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uploadtrack.Id)
            {
                return BadRequest();
            }

            db.Entry(uploadtrack).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UploadTrackExists(id))
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

        // POST api/UploadTracks
        [ResponseType(typeof(UploadTrack))]
        public IHttpActionResult PostUploadTrack(UploadTrack uploadtrack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UploadTracks.Add(uploadtrack);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uploadtrack.Id }, uploadtrack);
        }

        // DELETE api/UploadTracks/5
        [ResponseType(typeof(UploadTrack))]
        public IHttpActionResult DeleteUploadTrack(long id)
        {
            UploadTrack uploadtrack = db.UploadTracks.Find(id);
            if (uploadtrack == null)
            {
                return NotFound();
            }

            db.UploadTracks.Remove(uploadtrack);
            db.SaveChanges();

            return Ok(uploadtrack);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UploadTrackExists(long id)
        {
            return db.UploadTracks.Count(e => e.Id == id) > 0;
        }
    }
}