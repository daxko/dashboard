using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class PerformanceController : Controller
    {
        public ActionResult LongestRunningPages()
        {
            return View();
        }
    }
}
