﻿using System;
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
using Sample.ViewModels;

namespace Sample.Controllers
{
    public class ErrorsController : ApiController
    {
        private SampleContext db = new SampleContext();

        // GET api/Errors
        public List<ErrorViewModel> GetErrors()
        {
            List<ErrorViewModel> list = new List<ErrorViewModel>();
            var items = db.Errors.Include("Task");
            foreach (var item in items)
            {
                list.Add(new ErrorViewModel() { TaskId = item.TaskId, Name = item.Name, Description = item.Description, Weightage = item.Weightage });
            }
            return list;
        }

        // GET api/Errors/5
        [ResponseType(typeof(Error))]
        public IHttpActionResult GetError(int id)
        {
            Error error = db.Errors.Find(id);
            if (error == null)
            {
                return NotFound();
            }

            return Ok(error);
        }

        // PUT api/Errors/5
        public IHttpActionResult PutError(int id, Error error)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != error.Id)
            {
                return BadRequest();
            }

            db.Entry(error).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorExists(id))
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

        // POST api/Errors
        [ResponseType(typeof(Error))]
        public IHttpActionResult PostError(Error error)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Errors.Add(error);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = error.Id }, error);
        }

        // DELETE api/Errors/5
        [ResponseType(typeof(Error))]
        public IHttpActionResult DeleteError(int id)
        {
            Error error = db.Errors.Find(id);
            if (error == null)
            {
                return NotFound();
            }

            db.Errors.Remove(error);
            db.SaveChanges();

            return Ok(error);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ErrorExists(int id)
        {
            return db.Errors.Count(e => e.Id == id) > 0;
        }
    }
}