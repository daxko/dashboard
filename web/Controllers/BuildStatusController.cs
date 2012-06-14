using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class BuildStatusController : Controller
    {
        public ActionResult Ops()
        {
            var model = new OpsBuildStatusViewModel();
            return View(model);
        }
    }
}
