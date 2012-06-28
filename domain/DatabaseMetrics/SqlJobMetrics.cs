using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.DatabaseMetrics
{
    public class SqlJobMetrics
    {
        public string job_name { get; set; }
        public string message { get; set; }
        public DateTime last_run { get; set; }
        public job_outcomes job_status { get; set; }
        public int job_step { get; set; }

        public enum job_outcomes 
        {
            failed = 0,
            success = 1,
            unknown = -1
        }
    }
}
