using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.DatabaseMetrics
{
    public interface ISqlJobMetricRepository
    {
        IEnumerable<SqlJobMetrics> get_job_metrics_for_last_24_hours();
    }
}
