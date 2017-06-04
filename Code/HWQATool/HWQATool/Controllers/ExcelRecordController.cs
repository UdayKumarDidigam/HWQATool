using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HWQATool.Models;
using System.IO;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace HWQATool.Controllers
{
    public class ExcelRecordController : Controller
    {
        private HWQAToolContext db = new HWQAToolContext();

        // GET: /ExcelRecord/
        public ActionResult Index()
        {
            var excelrecords = db.ExcelRecords.Include(e => e.Team);
            return View(excelrecords.ToList());
        }

        // GET: /ExcelRecord/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcelRecord excelrecord = db.ExcelRecords.Find(id);
            if (excelrecord == null)
            {
                return HttpNotFound();
            }
            return View(excelrecord);
        }

        // GET: /ExcelRecord/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: /ExcelRecord/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,TeamId,IsError,ErrorCode,Client,Task,Platform,Processor,ProcessDate,ServiceRequestNo,AuditNo,BatchNo,FileNo,NoOfRecords,Auditor")] ExcelRecord excelrecord)
        {
            if (ModelState.IsValid)
            {
                db.ExcelRecords.Add(excelrecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", excelrecord.TeamId);
            return View(excelrecord);
        }

        // GET: /ExcelRecord/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcelRecord excelrecord = db.ExcelRecords.Find(id);
            if (excelrecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", excelrecord.TeamId);
            return View(excelrecord);
        }

        // POST: /ExcelRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,TeamId,IsError,ErrorCode,Client,Task,Platform,Processor,ProcessDate,ServiceRequestNo,AuditNo,BatchNo,FileNo,NoOfRecords,Auditor")] ExcelRecord excelrecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excelrecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", excelrecord.TeamId);
            return View(excelrecord);
        }

        // GET: /ExcelRecord/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcelRecord excelrecord = db.ExcelRecords.Find(id);
            if (excelrecord == null)
            {
                return HttpNotFound();
            }
            return View(excelrecord);
        }

        // POST: /ExcelRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ExcelRecord excelrecord = db.ExcelRecords.Find(id);
            db.ExcelRecords.Remove(excelrecord);
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

        public void ExportListUsingEPPlus()
        {
            var data = db.ExcelRecords.Include(e => e.Team);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.Cells[1, 1].LoadFromCollection(data, true);
            workSheet.Cells["C2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells["C2"].Style.Fill.BackgroundColor.SetColor(Color.Red);
            workSheet.Cells["C2"].AddComment("Hello", "System");



            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Contact.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
    }
}
