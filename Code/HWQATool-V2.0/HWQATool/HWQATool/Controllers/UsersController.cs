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
    public class UsersController : ApiController
    {
        private HWQAToolContext db = new HWQAToolContext();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            string message;
            bool isValid = IsValidateUser(user, out message);
            if (isValid)
            {

                db.Entry(user).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(new GenericResponse() { Success = true, Message = message, Data = user });
            }
            else
            {
                return Ok(new GenericResponse() { Success = false, Message = message });
            }
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            string message;
            bool isValid = IsValidateUser(user, out message);
            if (isValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return Ok(new GenericResponse() { Success = true, Message = message, Data = user });
            }
            else
            {
                return Ok(new GenericResponse() { Success = false, Message = message, Data = user });
            }
        }


        private bool IsValidateUser(User user, out string Message)
        {
            if (user == null)
            {
                Message = "Invalid Object";
            }

            else if (string.IsNullOrEmpty(user.LoginId))
            {
                Message = "Please enter Login User";
                return false;
            }
            else if (user.LoginId.Length > 20)
            {
                Message = "Please enter Login User only 20 char's";
                return false;
            }
            else if (string.IsNullOrEmpty(user.AssociateId))
            {
                Message = "Please enter Associate Id";
                return false;
            }
            else if (user.AssociateId.Length > 10)
            {
                Message = "Please enter Associate Id only 10 char's";
                return false;
            }
            else if (string.IsNullOrEmpty(user.Email))
            {
                Message = "Please enter Email ID";
                return false;
            }
            else if (user.Email.Length > 200)
            {
                Message = "Please enter Email only 200 char's";
                return false;
            }
            else if (string.IsNullOrEmpty(user.Email))
            {
                //var emailAddress = new System.Net.Mail.MailAddress(user.Email);
                //emailAddress.Address == user.Email;
                Message = "Please Enter Valid Email Id";
                return false;
            }
            else if (string.IsNullOrEmpty(user.FirstName))
            {
                Message = "Please enter First Name";
                return false;
            }
            else if (user.FirstName.Length > 50)
            {
                Message = "Please enter First Name only 50 char(s)";
                return false;
            }
            else if (string.IsNullOrEmpty(user.LastName))
            {
                Message = "Please enter Last Name";
                return false;
            }
            else if (user.LastName.Length > 50)
            {
                Message = "Please enter Last Name only 50 char(s)";
                return false;
            }
            else if (string.IsNullOrEmpty(user.Supervoiser_Email))
            {
                Message = "Please enter Supervoiser Email ID";
                return false;
            }
            else if (user.Supervoiser_Email.Length > 200)
            {
                Message = "Please enter Supervoiser Email only 200 char's";
                return false;
            }
            else if (string.IsNullOrEmpty(user.Supervoiser_Email))
            {
                //var emailAddress = new System.Net.Mail.MailAddress(user.Supervoiser_Email);
                //return emailAddress.Address == user.Supervoiser_Email;
                Message = "Please Enter Valid Supervoiser Email Id";
                return false;
            }
            else if (user.GradeId == null)
            {
                Message = "Please enter Grade ID";
                return false;
            }
            else if (user.SamplePercentage == null)
            {
                Message = "Please enter Sample Percentage";
                return false;
            }
            else if (user.SamplePercentage < 0 || user.SamplePercentage > 100)
            {
                Message = "Please enter Sample Percentage 0 to 100";
                return false;
            }
            else if (user.Comments == null)
            {
                Message = "Please Enter Comments";
                return false;
            }
            else if (db.Users.Any(x => x.LoginId == user.LoginId && x.AssociateId == user.AssociateId && x.Email == user.Email && x.Location == user.Location && x.GradeId == user.GradeId && x.Id != user.Id))
            {
                Message = "User already exists";
                return false;
            }

            Message = "Success";
            return true;

        }



        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}