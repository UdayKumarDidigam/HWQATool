using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sample.ViewModels
{
    public class ErrorViewModel
    {
        public int TaskId { get; set; }
        public string Name { get; set; }

       public string Description { get; set; }

       public decimal Weightage { get; set; }

    }
}
