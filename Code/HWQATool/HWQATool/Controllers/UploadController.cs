using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
namespace FileUpload.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload  
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {

                        string _FileName = Guid.NewGuid() + fileExtension; //Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                        file.SaveAs(_path);
                        ViewBag.Message = "File Uploaded Successfully!!";
                    }
                    else
                    {
                        ViewBag.Message = "Please Upload Only Excel Files";
                    }
                }

                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
    }
}