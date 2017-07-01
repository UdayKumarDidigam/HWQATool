using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace HWQATool.ViewModels
{
    public class GenericResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }
    }
}