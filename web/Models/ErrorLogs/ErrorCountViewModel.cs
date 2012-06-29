using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models.ErrorLogs
{
    public class ErrorCountViewModel
    {
        public DateTime past_date { get; set; }
        public Int32 past_error_count { get; set; }
        public DateTime current_date { get; set; }
        public Int32 current_error_count { get; set; }
    }
}