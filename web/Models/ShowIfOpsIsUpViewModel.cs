using System;

namespace web.Models
{
    public class ShowIfOpsIsUpViewModel
    {
        public long refresh_time { get; set; }
        public string refresh_time_display { get { return String.Format("{0} seconds",refresh_time);}}
        public DateTime last_refreshed { get; set; }
        public ApplicationStatusIndicatorViewModel ops_1 { get; set; }
        public ApplicationStatusIndicatorViewModel ops_2 { get; set; }
        public ApplicationStatusIndicatorViewModel ops_3 { get; set; }

        public ShowIfOpsIsUpViewModel()
        {
            refresh_time = 30;
            last_refreshed = DateTime.Now;
        }
    }
}