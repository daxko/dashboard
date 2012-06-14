namespace web.Models
{
    public class WallboardViewModel
    {
        public long wallboard_id { get; set; }

        public string wallboard_iframe_link
        {
            get { return string.Format("{0}{1}", "http://jira:8090/plugins/servlet/Wallboard/?dashboardId=", wallboard_id); }
        }
    }
}