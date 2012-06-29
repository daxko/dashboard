using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.DatabaseMetrics
{
    public class ErrorLogMetrics
    {
        public Int32 error_count { get; set; }
        public string error { get; set; }
        public DateTime past_date { get; set; }
        public Int32 past_error_count { get; set; }
        public DateTime current_date { get; set; }
        public Int32 current_error_count { get; set; }
        //public DateTime last_run { get; set; }
        //public job_outcomes job_status { get; set; }

        //public enum job_outcomes 
        //{
        //    failed = 0,
        //    success = 1,
        //    unknown = -1
        //}

    }
}
