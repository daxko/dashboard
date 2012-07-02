using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.DatabaseMetrics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace domain_tests
{
    [TestClass]
    public class ErrorLogRepositoryTests : DBTests
    {

        private ErrorLogRepository error_log_repo;

        [TestInitialize]        
        public void setup()
        {
            base.setup();

            error_log_repo = new ErrorLogRepository(db_connection);
        }

        [TestMethod]
        public void getting_top_5_errors_from_db_will_return_5_records()
        {
            var results = error_log_repo.get_top_5_errors();

            Assert.IsNotNull(results);
            Assert.AreEqual(5, results.Count());

        }

        [TestMethod]
        public void getting_error_counts_from_db_will_be_proper_intervals_apart()
        {

            const int expected_day_interval = 7;

            var error_counts = error_log_repo.get_error_counts();

            Assert.IsNotNull(error_counts);

            var date_diff = error_counts.current_date - error_counts.past_date;

            Assert.AreEqual(expected_day_interval, date_diff.Days);

        }


    }
}
