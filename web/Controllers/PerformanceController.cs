using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using domain.DatabaseMetrics;
using web.Infrastructure;
using web.Models.DatabaseMetrics;
using web.Models.ErrorLogs;

namespace web.Controllers
{
    public class PerformanceController : Controller
    {

        private readonly ISqlJobMetricRepository sql_job_metric_repo;
        private readonly IErrorLogRepository error_log_repo;

        public PerformanceController(ISqlJobMetricRepository sql_job_metric_repo, IErrorLogRepository error_log_repo)
        {
            this.sql_job_metric_repo = sql_job_metric_repo;
            this.error_log_repo = error_log_repo;
        }

        public ActionResult LongestRunningPages()
        {
            return View();
        }

        private SqlJobMetricDashboardViewModel get_sql_metrics_dashboard_data()
        {
             var dashboard_view_model = new SqlJobMetricDashboardViewModel();

            var success_metrics_view_models = new List<SqlJobMetricViewModel>();
            var failed_metrics_view_models = new List<SqlJobMetricViewModel>();

            var job_metrics = sql_job_metric_repo.get_job_metrics_for_last_24_hours()
                .OrderBy(x => x.job_name)
                .ThenBy(x => x.job_step)
                .ToList();

            var success_metrics =
                job_metrics.Where(x => x.job_status == SqlJobMetrics.job_outcomes.success)
                    .ToList();

            var failed_metrics =
                job_metrics.Where(x => x.job_status == SqlJobMetrics.job_outcomes.failed)
                    .ToList();

            dashboard_view_model.successful_jobs_count = success_metrics.Count;
            dashboard_view_model.failed_jobs_count = failed_metrics.Count;
            dashboard_view_model.total_jobs_count = job_metrics.Count;

            foreach (var success_metric in success_metrics)
            {
                var success_view_model = build_sql_job_metric_view_model(success_metric);
                success_metrics_view_models.Add(success_view_model);
            }

            foreach (var failed_metric in failed_metrics)
            {
                var failed_view_model = build_sql_job_metric_view_model(failed_metric);
                failed_metrics_view_models.Add(failed_view_model);
            }

            dashboard_view_model.successful_jobs = success_metrics_view_models;
            dashboard_view_model.failed_jobs = failed_metrics_view_models;

            return dashboard_view_model;

        }

        public ActionResult SqlJobMetricsDashboard()
        {
            var dashboard_view_model = get_sql_metrics_dashboard_data();

            return View(dashboard_view_model);
        }

        public ActionResult ErrorLogDataDashboard()
        {

            var error_log_view_model = new List<ErrorLogViewModel>();
            var error_counts = error_log_repo.get_error_counts();

            var errors = error_log_repo.get_top_5_errors();
            foreach (var error in errors)
            {
                error_log_view_model.Add(new ErrorLogViewModel { error = error.error, error_count = error.error_count });
            }

            var error_count_view_model = new ErrorCountViewModel();
            error_count_view_model.current_date = error_counts.current_date;
            error_count_view_model.current_error_count = error_counts.current_error_count;
            error_count_view_model.past_date = error_counts.past_date;
            error_count_view_model.past_error_count = error_counts.past_error_count;

            return View(new ErrorDashboardViewModel {error_logs = error_log_view_model, error_counts = error_count_view_model});

        }

        private SqlJobMetricViewModel build_sql_job_metric_view_model(SqlJobMetrics metric)
        {
               var metric_view_model = new SqlJobMetricViewModel();
                metric_view_model.job_name = metric.job_name;
                metric_view_model.last_run = metric.last_run.ToString("M.d.yyyy h:mm");
                metric_view_model.message = metric.message;
                metric_view_model.job_step = metric.job_step.ToString();

            return metric_view_model;
        }


    }
}
