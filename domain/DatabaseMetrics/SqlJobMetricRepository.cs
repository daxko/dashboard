using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace domain.DatabaseMetrics
{
    public class SqlJobMetricRepository : ISqlJobMetricRepository
    {

        private readonly IDbConnection db_connection;

        public SqlJobMetricRepository(IDbConnection db_connection)
        {
            this.db_connection = db_connection;
        }

        public IEnumerable<SqlJobMetrics> get_job_metrics_for_last_24_hours()
        {
            var results = new List<SqlJobMetrics>();

            const string sql =
                @"select j.name,
                   h.message,
                   success_status = case h.run_status
                                        when 1 then 1 /* success */
                                        else 0 /* failure */
                                    end,
                    last_run_datetime = CONVERT(DATETIME, CONVERT(CHAR(8), run_date, 112) + ' ' + STUFF(STUFF(RIGHT('000000' + CONVERT(VARCHAR(8), run_time), 6), 5, 0, ':'), 3, 0, ':'), 121),
                    h.step_id
                from msdb.dbo.sysjobhistory h
                inner join msdb..sysjobs j on h.job_id = j.job_id
                where CONVERT(DATETIME, CONVERT(CHAR(8), run_date, 112) + ' ' + STUFF(STUFF(RIGHT('000000' + CONVERT(VARCHAR(8), run_time), 6), 5, 0, ':'), 3, 0, ':'), 121) 
                    > DATEADD(HOUR, -24, GETDATE())
                ";

            var select_cmd = new SqlCommand(sql);
            select_cmd.Connection = (SqlConnection) db_connection;

            if(db_connection.State == ConnectionState.Closed)
                db_connection.Open();

            var reader = select_cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while(reader.Read())
            {
                var metric = build_sql_job_metric_from_reader(reader);
                results.Add(metric);
            }

            return results;

        }

        SqlJobMetrics build_sql_job_metric_from_reader(SqlDataReader reader)
        {
            var metric = new SqlJobMetrics();

            metric.job_name = reader.GetString(0);
            metric.message = reader.GetString(1);

            var job_outcome_key = reader.GetInt32(2);
            metric.job_status = get_job_outcome_from_key(job_outcome_key);

            metric.last_run = reader.GetDateTime(3);
            metric.job_step = reader.GetInt32(4);

            return metric;
        }

        SqlJobMetrics.job_outcomes get_job_outcome_from_key(int key)
        {

            var outcome = SqlJobMetrics.job_outcomes.unknown;

             switch(key)
                {
                    case 0:
                        outcome = SqlJobMetrics.job_outcomes.failed;
                        break;
                    case 1:
                        outcome = SqlJobMetrics.job_outcomes.success;
                        break;
                }

            return outcome;

        }


    }
}
