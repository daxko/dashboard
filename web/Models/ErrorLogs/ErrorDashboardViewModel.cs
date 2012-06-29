using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models.ErrorLogs
{
    public class ErrorDashboardViewModel
    {
        public IEnumerable<ErrorLogViewModel> error_logs { get; set; }
        public ErrorCountViewModel error_counts { get; set; }
    }
}