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
    public class ClientsController : ApiController
    {
        private HWQAToolContext db = new HWQAToolContext();

        // GET: api/Clients
        public IQueryable<Client> GetClients()
        {
            return db.Clients;
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            string message;
            bool isValid = IsValidateClient(client, out message);
            if (isValid)
            {
                db.Entry(client).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new GenericResponse() { Success = true, Message = message, Data = client });
            }
            else
            {
                return Ok(new GenericResponse() { Success = false, Message = message });
            }            
        }

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            string message;
            bool isValid = IsValidateClient(client, out message);
            if (isValid)
            {

                db.Clients.Add(client);
                db.SaveChanges();
                //return CreatedAtRoute("DefaultApi", new { id = client.Id }, client);
                return Ok(new GenericResponse() { Success = true, Message = message, Data = client });
            }
            else
            {
                return Ok(new GenericResponse() { Success = false, Message = message, Data = client });
            }
        }

        private bool IsValidateClient(Client client, out string Message)
        {
            if (client == null)
            {
                Message = "Invalid Object";
            }

            else if (string.IsNullOrEmpty(client.Name))
            {
                Message = "Please enter client name";
                return false;
            }
            else if (client.Name.Length > 50)
            {
                Message = "Please enter name only 50 char(s)";
                return false;
            }
            else if (client.TeamId == null)
            {
                Message = "Please enter Team ID";
                return false;
            }
            else if (client.IsKeyClient == null)
            {
                Message = "Invalid IsKeyClient";
                return false;
            }
            else if (client.SamplePercentage == null)
            {
                Message = "Please enter Sample Percentage";
                return false;
            }
            else if (client.SamplePercentage < 0 || client.SamplePercentage > 100)
            {
                Message = "Please enter Sample Percentage 0 to 100";
                return false;
            }
            else if (db.Clients.Any(x => x.Name == client.Name && x.Id != client.Id))
            {
                Message = "Client Name already exists";
                return false;
            }
            Message = "Success";
            return true;

        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.Id == id) > 0;
        }
    }
}