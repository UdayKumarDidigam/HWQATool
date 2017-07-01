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
    public class TeamsController : ApiController
    {
        /// <summary>
        /// Variables
        /// </summary>
        private HWQAToolContext db = new HWQAToolContext();

        // GET: api/Teams
        public IQueryable<Team> GetTeams()
        {
            return db.Teams;
        }

        // GET: api/Teams/5
        [ResponseType(typeof(Team))]
        public IHttpActionResult GetTeam(int id)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        // PUT: api/Teams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeam(int id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.Id)
            {
                return BadRequest();
            }

            db.Entry(team).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Teams
        [ResponseType(typeof(Team))]
        public IHttpActionResult PostTeam(Team team)
        {
            string message;
            bool isValid = IsValidateTeam(team, out message);
            if (isValid)
            {
                db.Teams.Add(team);
                db.SaveChanges();
                return Ok(new GenericResponse() { Success = true, Message = message, Data = team });
            }
            else
            {
                return Ok(new GenericResponse() { Success = false, Message = message });
            }
        }

        private bool IsValidateTeam(Team team, out string Message)
        {
            if (team == null)
            {
                Message = "Invalid object";
                return false;
            }
            else if (string.IsNullOrEmpty(team.Name))
            {
                Message = "Please enter name";
                return false;
            }
            else if (team.Name.Length > 50)
            {
                Message = "Please enter name only 50 char(s)";
                return false;
            }
            else if (team.QualityBenchMark == null)
            {
                Message = "Please enter quality bench mark";
                return false;
            }
            else if (team.QualityBenchMark < 0 || team.QualityBenchMark > 100)
            {
                Message = "Please enter quality bench mark 0 to 100";
                return false;
            }
            else if (db.Teams.Any(x => x.Name == team.Name && x.Id != team.Id))
            {
                Message = "Team name already exists";
                return false;
            }
            Message = "Success";
            return true;
        }

        // DELETE: api/Teams/5
        [ResponseType(typeof(Team))]
        public IHttpActionResult DeleteTeam(int id)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            db.SaveChanges();

            return Ok(team);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamExists(int id)
        {
            return db.Teams.Count(e => e.Id == id) > 0;
        }
    }
}