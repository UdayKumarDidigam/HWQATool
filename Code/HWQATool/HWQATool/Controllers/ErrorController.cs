using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HWQATool.Models;

namespace HWQATool.Controllers
{
    public class ErrorController : Controller
    {
        private HWQAToolContext db = new HWQAToolContext();

        // GET: /Error/
        public ActionResult Index()
        {
            var errors = db.Errors.Include(e => e.Task);
            return View(errors.ToList());
        }

        // GET: /Error/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Error error = db.Errors.Find(id);
            if (error == null)
            {
                return HttpNotFound();
            }
            return View(error);
        }

        // GET: /Error/Create
        public ActionResult Create()
        {
            ViewBag.TaskId = new SelectList(db.Functions, "Id", "Name");
            return View();
        }

        // POST: /Error/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,DESCRIPTION,WEIGHTAGE,TaskId,Version,LastModifiedAt,LastModifiedBy")] Error error)
        {
            if (ModelState.IsValid)
            {
                db.Errors.Add(error);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaskId = new SelectList(db.Functions, "Id", "Name", error.TaskId);
            return View(error);
        }

        // GET: /Error/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Error error = db.Errors.Find(id);
            if (error == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaskId = new SelectList(db.Functions, "Id", "Name", error.TaskId);
            return View(error);
        }

        // POST: /Error/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,DESCRIPTION,WEIGHTAGE,TaskId,Version,LastModifiedAt,LastModifiedBy")] Error error)
        {
            if (ModelState.IsValid)
            {
                db.Entry(error).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskId = new SelectList(db.Functions, "Id", "Name", error.TaskId);
            return View(error);
        }

        // GET: /Error/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Error error = db.Errors.Find(id);
            if (error == null)
            {
                return HttpNotFound();
            }
            return View(error);
        }

        // POST: /Error/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Error error = db.Errors.Find(id);
            db.Errors.Remove(error);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
