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
using HWQATool.ViewModels;

namespace HWQATool.Controllers
{
    public class SubTasksController : ApiController
    {
        private HWQAToolContext db = new HWQAToolContext();

        // GET: api/SubTasks
        public IQueryable<SubTask> GetSubTasks()
        {
            return db.SubTasks;
        }

        // GET: api/SubTasks/5
        [ResponseType(typeof(SubTask))]
        public IHttpActionResult GetSubTask(int id)
        {
            SubTask subTask = db.SubTasks.Find(id);
            if (subTask == null)
            {
                return NotFound();
            }

            return Ok(subTask);
        }

        // PUT: api/SubTasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubTask(int id, SubTask subTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subTask.Id)
            {
                return BadRequest();
            }

            db.Entry(subTask).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubTaskExists(id))
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

        // POST: api/SubTasks
        [ResponseType(typeof(SubTask))]
        public IHttpActionResult PostSubTask(SubTask subTask)
        {
            string message;
            bool isValid = IsValidateSubTask(subTask, out message);
            if (isValid)
            {
                db.SubTasks.Add(subTask);
                db.SaveChanges();
                //return CreatedAtRoute("DefaultApi", new { id = subTask.Id }, subTask);
                return Ok(new GenericResponse() { Success = true, Message = message, Data = subTask });
            }
            else
            {
                return Ok(new GenericResponse() { Success = false, Message = message });
            }
        }

        private bool IsValidateSubTask(SubTask subTask, out string Message)
        {
            if (subTask == null)
            {
                Message = "Invalid Object";
            }

            else if (string.IsNullOrEmpty(subTask.Name))
            {
                Message = "Please enter SubTask name";
                return false;
            }
            else if (subTask.Name.Length > 50)
            {
                Message = "Please enter name only 50 char(s)";
                return false;
            }
            else if (subTask.TaskId == null)
            {
                Message = "Please enter Task ID";
                return false;
            }
            else if (db.SubTasks.Any(x => x.Name == subTask.Name && x.Id != subTask.Id))
            {
                Message = "SubTask Name already exists";
                return false;
            }
            Message = "Success";
            return true;
        }


        // DELETE: api/SubTasks/5
        [ResponseType(typeof(SubTask))]
        public IHttpActionResult DeleteSubTask(int id)
        {
            SubTask subTask = db.SubTasks.Find(id);
            if (subTask == null)
            {
                return NotFound();
            }

            db.SubTasks.Remove(subTask);
            db.SaveChanges();

            return Ok(subTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubTaskExists(int id)
        {
            return db.SubTasks.Count(e => e.Id == id) > 0;
        }
    }
}