using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models.ErrorLogs
{
    public class ErrorLogViewModel
    {
        public Int32 error_count { get; set; }
        public string error { get; set; }
        public DateTime past_date {get; set;}
        public Int32 past_error_count { get; set; }
        public DateTime current_date { get; set; }
        public Int32 current_error_count { get; set; }
        //public string last_run { get; set; }
    }
}