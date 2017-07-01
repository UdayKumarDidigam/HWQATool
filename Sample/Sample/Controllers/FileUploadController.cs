using HWQATool.Models;
using OfficeOpenXml;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sample.Controllers
{
    public class FileUploadController : ApiController
    {
        private SampleContext db = new SampleContext();
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
                            NoOfRecords = ExcelHelper.ParseWorksheetValue(workSheet, header, rowIndex, "NoOfRecords "),
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


        public void ReadExcel(int teamId, string filePath,long trackId)
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
            }
            catch(Exception ex)
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
                        UploadTrack uploadtrack = new UploadTrack() { FileName = Path.GetFileName(hpf.FileName), OriginalFileName = Path.GetFileName(hpf.FileName),Status= TrackStatus.Submitted,TeamId=this.TeamId};
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


        public int TeamId { get; set; }
    }
}
