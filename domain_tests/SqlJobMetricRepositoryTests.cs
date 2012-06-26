using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using domain.DatabaseMetrics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace domain_tests
{
    [TestClass]
    public class SqlJobMetricRepositoryTests : DBTests
    {
        [TestMethod]
        public void can_get_sql_job_metrics_for_the_past_24_hours_from_db()
        {
            var repo = new SqlJobMetricRepository(db_connection);

            var results = repo.get_job_metrics_for_last_24_hours();

            Assert.IsNotNull(results);
            Assert.AreNotEqual(0, results.Count());
        }
    }
}
