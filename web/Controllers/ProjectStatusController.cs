using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class ProjectStatusController : Controller
    {
        [HttpGet]
        public ActionResult Wallboard(long id)
        {
            var model = new WallboardViewModel()
                            {
                                wallboard_id = id
                            };

            return View(model);
        }

        [HttpGet]
        public ActionResult MembersOnly()
        {
            return RedirectToAction("Wallboard", new {id = "11480"});
        }

        [HttpGet]
        public ActionResult ChildCare()
        {
            return RedirectToAction("Wallboard", new {id = "11587"});
        }
    }
}
