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
    public class PlatformsController : ApiController
    {
        private SampleContext db = new SampleContext();

        // GET api/Platforms
        public IQueryable<Platform> GetPlatforms()
        {
            return db.Platforms.Include("Team");
        }

        // GET api/Platforms/5
        [ResponseType(typeof(Platform))]
        public IHttpActionResult GetPlatform(int id)
        {
            Platform platform = db.Platforms.Find(id);
            if (platform == null)
            {
                return NotFound();
            }

            return Ok(platform);
        }

        // PUT api/Platforms/5
        public IHttpActionResult PutPlatform(int id, Platform platform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != platform.Id)
            {
                return BadRequest();
            }

            db.Entry(platform).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatformExists(id))
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

        // POST api/Platforms
        [ResponseType(typeof(Platform))]
        public IHttpActionResult PostPlatform(Platform platform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Platforms.Add(platform);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = platform.Id }, platform);
        }

        // DELETE api/Platforms/5
        [ResponseType(typeof(Platform))]
        public IHttpActionResult DeletePlatform(int id)
        {
            Platform platform = db.Platforms.Find(id);
            if (platform == null)
            {
                return NotFound();
            }

            db.Platforms.Remove(platform);
            db.SaveChanges();

            return Ok(platform);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlatformExists(int id)
        {
            return db.Platforms.Count(e => e.Id == id) > 0;
        }
    }
}