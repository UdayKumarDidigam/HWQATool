using HWQATool.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWQATool.Controllers
{
    public class ExcelReadController : Controller
    {
        private HWQAToolContext db = new HWQAToolContext();

        private int TeamId;
        //
        // GET: /ExcelRead/
        public ActionResult Index(int teamId)
        {
            this.TeamId = teamId;
            string Path = @"C:\project\HWQATool\Code\HWQATool\HWQATool\Ajjuexcel1.xlsx";
            FileInfo fi = new FileInfo(Path);

            if (!fi.Exists)
            {
                throw new Exception("File " + Path + " Does not exist.");
            }
            ExcelPackage package = new ExcelPackage(fi);

            ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];
            IEnumerable<ExcelRecord> records = PopulateRecords(workSheet, true);
            db.ExcelRecords.AddRange(records);
            db.SaveChanges();
            //Response.Write("Records count: " + records.Count());


            return View();
        }


        ///<summary>
        /// Populate record objects from spreadsheet
        /// </summary>

        /// <param name="workSheet"></param>
        /// <param name="firstRowHeader"></param>
        /// <returns></returns>
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

    }
}