using HWQATool.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Sample.Controllers
{
    public class FileUploadController : ApiController
    {
        private SampleContext db = new SampleContext();
        [HttpGet()]
        [Route("api/file/download/{teamId}/{trackId}")]
        public void Download(int teamId, int trackId)
        {

            var records = db.ExcelRecords.Where(x => x.TeamId == teamId && x.UploadTrackId == trackId);

            //var students = new[]
            //{
            //    new {
            //        Id = "101", Name = "Vivek", Address = "Hyderabad"
            //    },
            //    new {
            //        Id = "102", Name = "Ranjeet", Address = "Hyderabad"
            //    },
            //    new {
            //        Id = "103", Name = "Sharath", Address = "Hyderabad"
            //    },
            //    new {
            //        Id = "104", Name = "Ganesh", Address = "Hyderabad"
            //    },
            //    new {
            //        Id = "105", Name = "Gajanan", Address = "Hyderabad"
            //    },
            //    new {
            //        Id = "106", Name = "Ashish", Address = "Hyderabad"
            //    }
            //};
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            //Header of table  
            //  
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Cells[1, 1].Value = "Client";
            workSheet.Cells[1, 2].Value = "Task";
            workSheet.Cells[1, 3].Value = "Platform";
            workSheet.Cells[1, 4].Value = "Processor";
            workSheet.Cells[1, 5].Value = "ProcessDate";
            workSheet.Cells[1, 6].Value = "ServiceRequestNo";
            workSheet.Cells[1, 7].Value = "AuditNo";
            workSheet.Cells[1, 8].Value = "BatchNo";
            workSheet.Cells[1, 9].Value = "FileNo";
            workSheet.Cells[1, 10].Value = "NoOfRecords";
            workSheet.Cells[1, 11].Value = "Auditor";
             workSheet.Cells[1, 12].Value = "Success";
            workSheet.Cells[1, 13].Value = "Comments";
         
            //Body of table  
            //  
            int recordIndex = 2;
            foreach (var record in records)
            {
                workSheet.Cells[recordIndex, 1].Value = record.Client;
                workSheet.Cells[recordIndex, 2].Value = record.Task;
                workSheet.Cells[recordIndex, 3].Value = record.Platform;
                workSheet.Cells[recordIndex, 4].Value = record.Processor;
                workSheet.Cells[recordIndex, 5].Value = record.ProcessDate;
                workSheet.Cells[recordIndex, 6].Value = record.ServiceRequestNo;
                workSheet.Cells[recordIndex, 7].Value = record.AuditNo;
                workSheet.Cells[recordIndex, 8].Value = record.BatchNo;
                workSheet.Cells[recordIndex, 9].Value = record.FileNo;
                workSheet.Cells[recordIndex, 10].Value = record.NoOfRecords;
                workSheet.Cells[recordIndex, 11].Value = record.Auditor;
                workSheet.Cells[recordIndex, 12].Value = record.IsError?"No":"Yes";
                workSheet.Cells[recordIndex, 13].Value = record.ErrorCode;
                recordIndex++;
            }
            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();
            workSheet.Column(4).AutoFit();
            string excelName = "studentsRecord";
            using (var memoryStream = new MemoryStream())
            {
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + excelName + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();

            }
        }
        IEnumerable<ExcelRecord> PopulateRecords(ExcelWorksheet workSheet, bool firstRowHeader)
        {
            IList<ExcelRecord> records = new List<ExcelRecord>();

            if (workSheet != null)
            {
                Dictionary<string, int> header = new Dictionary<string, int>();

                for (int rowIndex = workSheet.Dimension.Start.Row; rowIndex <= workSheet.Dimension.End.Row; rowIndex++)
                {
                    //Assume the first row is the header. Then use the column match ups by name to determine the index.
                    //This will allow you to have the order of the columns change without any affect.

                    if (rowIndex == 1 && firstRowHeader)
                    {
                        header = ExcelHelper.GetExcelHeader(workSheet, rowIndex);
                    }
                    else
                    {
                        records.Add(new ExcelRecord
                        {
                            //Id = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "Id"),
                            TeamId = this.TeamId,//ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "TeamId"),
                            //IsError = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "IsError"),
                            //ErrorCode = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "ErrorCode"),
                            Client = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "Client"),
                            Task = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "Task"),
                            Platform = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "Platform"),
                            Processor = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "Processor"),
                            ProcessDate = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "ProcessDate"),
                            ServiceRequestNo = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "ServiceRequestNo"),
                            AuditNo = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "AuditNo"),
                            BatchNo = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "BatchNo"),
                            FileNo = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "FileNo"),
                            NoOfRecords = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "NoOfRecords"),
                            Auditor = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "Auditor"),
                        });

                    }
                }
            }

            return records;
        }

        public static class ExcelHelper
        {
            ///<summary>
            /// Gets the excel header and creates a dictionary object based on column name in order to get the index.
            /// Assumes that each column name is unique.
            /// </summary>

            /// <param name="workSheet"></param>
            /// <returns></returns>
            public static Dictionary<string, int> GetExcelHeader(ExcelWorksheet workSheet, int rowIndex)
            {
                Dictionary<string, int> header = new Dictionary<string, int>();

                if (workSheet != null)
                {
                    for (int columnIndex = workSheet.Dimension.Start.Column; columnIndex <= workSheet.Dimension.End.Column; columnIndex++)
                    {
                        if (workSheet.Cells[rowIndex, columnIndex].Value != null)
                        {
                            string columnName = workSheet.Cells[rowIndex, columnIndex].Value.ToString();

                            if (!header.ContainsKey(columnName) && !string.IsNullOrEmpty(columnName))
                            {
                                header.Add(columnName, columnIndex);
                            }
                        }
                    }
                }

                return header;
            }

            ///<summary>
            /// Parse worksheet values based on the information given.
            /// </summary>

            /// <param name="workSheet"></param>
            /// <param name="rowIndex"></param>
            /// <param name="columnName"></param>
            /// <returns></returns>
            public static string ParseWorksheetValue(ExcelWorksheet workSheet, Dictionary<string, int> header, int rowIndex, string columnName)
            {
                string value = string.Empty;
                int? columnIndex = header.ContainsKey(columnName) ? header[columnName] : (int?)null;

                if (workSheet != null && columnIndex != null && workSheet.Cells[rowIndex, columnIndex.Value].Value != null)
                {
                    value = workSheet.Cells[rowIndex, columnIndex.Value].Value.ToString();
                }

                return value;
            }
        }


        public void ReadExcel(int teamId, string filePath, long trackId)
        {

            this.TeamId = teamId;
            string _path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Uploads/"), filePath);
            FileInfo fi = new FileInfo(_path);

            if (!fi.Exists)
            {
                throw new Exception("File " + _path + " Does not exist.");
            }

            var trackRecord = db.UploadTracks.First(x => x.FileName == filePath);
            trackRecord.Status = TrackStatus.Queued;

            ExcelPackage package = new ExcelPackage(fi);
            ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];
            IEnumerable<ExcelRecord> records = PopulateRecords(workSheet, true);
            foreach (var item in records)
            {
                item.UploadTrackId = trackId;
            }
            db.ExcelRecords.AddRange(records);
            try
            {
                db.SaveChanges();
                System.Threading.Tasks.Task task = new System.Threading.Tasks.Task(new Action(() => ValidateRecords(TeamId, trackId)));
                task.Start();
            }
            catch (Exception ex)
            {

            }
        }

        private void ValidateRecords(int TeamId, long trackId)
        {
            IEnumerable<ExcelRecord> records = db.ExcelRecords.Where(x => x.TeamId == TeamId && x.UploadTrackId == trackId);
            IEnumerable<Client> clients = db.Clients.Where(x => x.TeamId == TeamId);
            IEnumerable<Task> tasks = db.Tasks.Where(x => x.TeamId == TeamId);
            IEnumerable<Platform> platforms = db.Platforms.Where(x => x.TeamId == TeamId);
            IEnumerable<User> users = db.Users;
            List<Audit> audits = new List<Audit>();
            foreach (var item in records)
            {
                var audit = new Audit();
                if (clients.Any(x => x.Name == item.Client))
                {
                    audit.ClientId = clients.Single(x => x.Name == item.Client).Id;
                }
                else
                {
                    item.IsError = true;
                    item.ErrorCode =item.ErrorCode+"Invalid client";
                }
                if (tasks.Any(x => x.Name == item.Task))
                {
                    audit.TaskId = tasks.Single(x => x.Name == item.Task).Id;
                }
                else
                {
                    item.IsError = true;
                    item.ErrorCode = item.ErrorCode+"Invalid task";
                }
                if (platforms.Any(x => x.Name == item.Platform))
                {
                    audit.PlatformId = platforms.Single(x => x.Name == item.Platform).Id;

                }
                else
                {
                    item.IsError = true;
                    item.ErrorCode =item.ErrorCode+"Invalid platform";
                }
                if (users.Any(x => x.LoginId == item.Processor))
                {
                    audit.Processor = users.Single(x => x.LoginId == item.Processor).Id;
                }
                else
                {
                    item.IsError = true;
                    item.ErrorCode = item.ErrorCode+"Invalid processor";
                }
                if (users.Any(x => x.LoginId == item.Auditor))
                {
                    audit.Auditor = users.Single(x => x.LoginId == item.Auditor).Id;
                }
                else
                {
                    item.IsError = true;
                    item.ErrorCode = item.ErrorCode+"Invalid auditor";
                }
                DateTime dt;
                if (DateTime.TryParse(item.ProcessDate, out dt))
                {
                    audit.ProcessedDate = dt;
                }
                else
                {
                    item.IsError = true;
                    item.ErrorCode =item.ErrorCode+"Invalid date";
                }
                int no;
                if (Int32.TryParse(item.NoOfRecords, out no))
                {
                    audit.NoOfRecords = no;
                }
                else
                {
                    item.IsError = true;
                    item.ErrorCode =item.ErrorCode+"Invalid No Of Records";
                }
                try
                {
                    if (!item.IsError)
                    {
                        db.Audits.Add(audit);

                    }
                    //var rec = db.ExcelRecords.Where(x => x.Id == item.Id);
                    //rec = item;

                }
                catch (Exception e)
                {

                }
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }


        }
        [HttpPost()]
        public string UploadFiles()
        {
            this.TeamId = 1;
            int iUploadedCnt = 0;

            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = "";
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Uploads/");

            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            // CHECK THE FILE COUNT.
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                System.Web.HttpPostedFile hpf = hfc[iCnt];

                if (hpf.ContentLength > 0)
                {
                    // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                    {
                        // SAVE THE FILES IN THE FOLDER.
                        hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
                        iUploadedCnt = iUploadedCnt + 1;
                        UploadTrack uploadtrack = new UploadTrack() { FileName = Path.GetFileName(hpf.FileName), OriginalFileName = Path.GetFileName(hpf.FileName), Status = TrackStatus.Submitted, TeamId = this.TeamId };
                        uploadtrack = db.UploadTracks.Add(uploadtrack);

                        try
                        {
                            db.SaveChanges();
                            System.Threading.Tasks.Task task = new System.Threading.Tasks.Task(new Action(() => ReadExcel(TeamId, hpf.FileName, uploadtrack.Id)));
                            task.Start();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }


            // RETURN A MESSAGE (OPTIONAL).
            if (iUploadedCnt > 0)
            {
                return iUploadedCnt + " Files Uploaded Successfully";
            }
            else
            {
                return "Upload Failed";
            }
        }

        [HttpGet]
        public void Validate(int teamId, long trackid)
        {
            ValidateRecords(teamId, trackid);
        }

        public int TeamId { get; set; }
    }
}
