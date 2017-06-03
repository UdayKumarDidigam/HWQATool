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
    public class AuditController : Controller
    {
        private HWQAToolContext db = new HWQAToolContext();

        // GET: /Audit/
        public ActionResult Index()
        {
            var audits = db.Audits.Include(a => a.Client).Include(a => a.Platform).Include(a => a.SubTask);
            return View(audits.ToList());
        }

        // GET: /Audit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audit audit = db.Audits.Find(id);
            if (audit == null)
            {
                return HttpNotFound();
            }
            return View(audit);
        }

        // GET: /Audit/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");
            ViewBag.PlatformId = new SelectList(db.Platforms, "Id", "Name");
            ViewBag.SubTaskId = new SelectList(db.SubTasks, "Id", "Name");
            return View();
        }

        // POST: /Audit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,AuditNumber,BatchNumber,FileNumber,ServiceRequestNumber,ProcessedDate,Processor,PlatformId,SubTaskId,ClientId,Auditor,AuditDate,AuditorComments,ISDefect,IsLearning,IsEscalation,IsClientFocus,IsDuplicate,IsSampled,NoOfRecords,Status,Version,LastModifiedAt,LastModifiedBy")] Audit audit)
        {
            if (ModelState.IsValid)
            {
                db.Audits.Add(audit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", audit.ClientId);
            ViewBag.PlatformId = new SelectList(db.Platforms, "Id", "Name", audit.PlatformId);
            ViewBag.SubTaskId = new SelectList(db.SubTasks, "Id", "Name", audit.SubTaskId);
            return View(audit);
        }

        // GET: /Audit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audit audit = db.Audits.Find(id);
            if (audit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", audit.ClientId);
            ViewBag.PlatformId = new SelectList(db.Platforms, "Id", "Name", audit.PlatformId);
            ViewBag.SubTaskId = new SelectList(db.SubTasks, "Id", "Name", audit.SubTaskId);
            return View(audit);
        }

        // POST: /Audit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,AuditNumber,BatchNumber,FileNumber,ServiceRequestNumber,ProcessedDate,Processor,PlatformId,SubTaskId,ClientId,Auditor,AuditDate,AuditorComments,ISDefect,IsLearning,IsEscalation,IsClientFocus,IsDuplicate,IsSampled,NoOfRecords,Status,Version,LastModifiedAt,LastModifiedBy")] Audit audit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", audit.ClientId);
            ViewBag.PlatformId = new SelectList(db.Platforms, "Id", "Name", audit.PlatformId);
            ViewBag.SubTaskId = new SelectList(db.SubTasks, "Id", "Name", audit.SubTaskId);
            return View(audit);
        }

        // GET: /Audit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audit audit = db.Audits.Find(id);
            if (audit == null)
            {
                return HttpNotFound();
            }
            return View(audit);
        }

        // POST: /Audit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Audit audit = db.Audits.Find(id);
            db.Audits.Remove(audit);
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
