﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace domain.DatabaseMetrics
{
    public class ErrorLogRepository : IErrorLogRepository
    {

        private readonly IDbConnection db_connection;

        public ErrorLogRepository(IDbConnection db_connection)
        {
            this.db_connection = db_connection;
        }

        public IEnumerable<ErrorLogMetrics> get_top_5_errors()
        {
            var errors = new List<ErrorLogMetrics>();

            const string sql =
                @"select * from ProductionSupport.dbo.Dashboard_CommonOpsErrors_Keep where ErrorTimestamp = (
	                select MAX(errortimestamp) from ProductionSupport.dbo.Dashboard_CommonOpsErrors_Keep)
                  order by ErrorCount desc";

            var select_cmd = new SqlCommand(sql);
            select_cmd.Connection = (SqlConnection)db_connection;

            if (db_connection.State == ConnectionState.Closed)
                db_connection.Open();

            var reader = select_cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                var metric = build_error_log_from_reader(reader);
                errors.Add(metric);
            }

            if (db_connection.State == ConnectionState.Open)
                db_connection.Close();

            return errors;

        }

        public ErrorLogMetrics get_error_counts()
        {
            var counts = new ErrorLogMetrics();

            const string sql =
                @"select top 1 *
                  from ProductionSupport.dbo.Dashboard_ErrorCounts_Keep
                  where CurrentDate = (
	                select MAX(CurrentDate) from ProductionSupport.dbo.Dashboard_ErrorCounts_Keep)";

            var select_cmd = new SqlCommand(sql);
            select_cmd.Connection = (SqlConnection)db_connection;

            if (db_connection.State == ConnectionState.Closed)
                db_connection.Open();

            var reader = select_cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                counts = build_error_counts_from_reader(reader);
            }

            if (db_connection.State == ConnectionState.Open)
                db_connection.Close();

            return counts;

        }

        ErrorLogMetrics build_error_log_from_reader(SqlDataReader reader)
        {
            var metric = new ErrorLogMetrics();

            metric.error_count = reader.GetInt32(1);
            metric.error = reader.GetString(2);

            return metric;
        }

        ErrorLogMetrics build_error_counts_from_reader(SqlDataReader reader)
        {
            var counts = new ErrorLogMetrics();

            counts.current_date = reader.GetDateTime(3);
            counts.current_error_count = reader.GetInt32(4);
            counts.past_date = reader.GetDateTime(1);
            counts.past_error_count = reader.GetInt32(2);

            return counts;
        }


    }
}
