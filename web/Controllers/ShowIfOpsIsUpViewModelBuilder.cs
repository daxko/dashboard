using System;
using System.Net;
using web.Models;

namespace web.Controllers
{
    public class ShowIfOpsIsUpViewModelBuilder
    {
        const string ops_1_url = "https://174.143.230.131:51181/default.aspx";
        const string ops_2_url = "https://174.143.230.131:52181/default.aspx";
        const string ops_3_url = "https://174.143.230.131:53181/default.aspx";

        public ShowIfOpsIsUpViewModel build()
        {
            var model = new ShowIfOpsIsUpViewModel()
                            {
                                ops_1 = get_application_status_view_model("Ops1", ops_1_url),
                                ops_2 = get_application_status_view_model("Ops2", ops_2_url),
                                ops_3 = get_application_status_view_model("Ops3", ops_3_url),
                            };
            return model;
        } 

        ApplicationStatusIndicatorViewModel get_application_status_view_model(string name, string url)
        {
            allow_invalid_certificates();

            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse) request.GetResponse();

            var status = is_web_page_up(response);

            return new ApplicationStatusIndicatorViewModel()
                       {
                            name = name,
                            status = status
                       };
        }

        static void allow_invalid_certificates()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, errors) => true;
        }

        static bool is_web_page_up(HttpWebResponse response)
        {
            return (response.StatusCode == HttpStatusCode.OK);
        }
    }
}