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
    public class TaskController : Controller
    {
        private HWQAToolContext db = new HWQAToolContext();

        // GET: /Task/
        public ActionResult Index()
        {
            var functions = db.Functions.Include(f => f.Team);
            return View(functions.ToList());
        }

        // GET: /Task/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Function function = db.Functions.Find(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            return View(function);
        }

        // GET: /Task/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: /Task/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,SamplePercentage,TeamId,Version,LastModifiedAt,LastModifiedBy")] Function function)
        {
            if (ModelState.IsValid)
            {
                db.Functions.Add(function);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", function.TeamId);
            return View(function);
        }

        // GET: /Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Function function = db.Functions.Find(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", function.TeamId);
            return View(function);
        }

        // POST: /Task/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,SamplePercentage,TeamId,Version,LastModifiedAt,LastModifiedBy")] Function function)
        {
            if (ModelState.IsValid)
            {
                db.Entry(function).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", function.TeamId);
            return View(function);
        }

        // GET: /Task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Function function = db.Functions.Find(id);
            if (function == null)
            {
                return HttpNotFound();
            }
            return View(function);
        }

        // POST: /Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Function function = db.Functions.Find(id);
            db.Functions.Remove(function);
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
