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
using Sample.ViewModels;

namespace Sample.Controllers
{
    public class SubTasksController : ApiController
    {
        private SampleContext db = new SampleContext();

        // GET api/SubTasks
        public List<SubTaskViewModel> GetSubTasks()
        {
            List<SubTaskViewModel> list = new List<SubTaskViewModel>();
            var items = db.SubTasks.Include("Task");
            foreach (var item in items)
            {
                list.Add(new SubTaskViewModel() { TaskId = item.TaskId, Name = item.Name });
            }
            return list;
        }

        // GET api/SubTasks/5
        [ResponseType(typeof(SubTask))]
        public IHttpActionResult GetSubTask(int id)
        {
            SubTask subtask = db.SubTasks.Find(id);
            if (subtask == null)
            {
                return NotFound();
            }

            return Ok(subtask);
        }

        // PUT api/SubTasks/5
        public IHttpActionResult PutSubTask(int id, SubTask subtask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subtask.Id)
            {
                return BadRequest();
            }

            db.Entry(subtask).State = EntityState.Modified;

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

        // POST api/SubTasks
        [ResponseType(typeof(SubTask))]
        public IHttpActionResult PostSubTask(SubTask subtask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubTasks.Add(subtask);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subtask.Id }, subtask);
        }

        // DELETE api/SubTasks/5
        [ResponseType(typeof(SubTask))]
        public IHttpActionResult DeleteSubTask(int id)
        {
            SubTask subtask = db.SubTasks.Find(id);
            if (subtask == null)
            {
                return NotFound();
            }

            db.SubTasks.Remove(subtask);
            db.SaveChanges();

            return Ok(subtask);
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