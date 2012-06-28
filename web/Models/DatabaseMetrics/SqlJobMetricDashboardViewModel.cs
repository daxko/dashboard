using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models.DatabaseMetrics
{
    public class SqlJobMetricDashboardViewModel
    {
        public IEnumerable<SqlJobMetricViewModel> failed_jobs { get; set; }
        public int failed_jobs_count { get; set; }
        public IEnumerable<SqlJobMetricViewModel> successful_jobs { get; set; }
        public int successful_jobs_count { get; set; }
        public int total_jobs_count { get; set; }
    }
}