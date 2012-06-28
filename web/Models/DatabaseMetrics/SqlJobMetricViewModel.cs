using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models.DatabaseMetrics
{
    public class SqlJobMetricViewModel
    {
        public string job_name { get; set; }
        public string message { get; set; }
        public string last_run { get; set; }
        public string job_step { get; set; }
    }
}