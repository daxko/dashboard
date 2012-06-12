using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Web;
using System.Web.Mvc;
using web.Infrastructure;
using web.Models;

namespace web.Controllers
{
    public class UptimeController : Controller
    {

        [HttpGet]
        public ActionResult ShowIfOpsIsUp()
        {
            var model = get_ops_application_status_view_model();
            return View(model);
        }

        [HttpGet]
        public ActionResult GetOpsApplicationStatus()
        {
            var model = get_ops_application_status_view_model();
            var view = this.RenderPartialViewToString("_OpsApplicationStatus",model);
            return Json(new {view}, JsonRequestBehavior.AllowGet);
        }

        ShowIfOpsIsUpViewModel get_ops_application_status_view_model()
        {
            return new ShowIfOpsIsUpViewModelBuilder().build();
        }

    }
}
