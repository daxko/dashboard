using System.Collections.Generic;
using System.Web.Mvc;
using domain.DatabaseMetrics;
using domain.Quotes;
using web.Infrastructure;
using web.Models;

namespace web.Controllers
{
    public class QuotesController : Controller
    {
        readonly IQuoteRepository quote_repository;

        public QuotesController(IQuoteRepository quote_repository)
        {

            this.quote_repository = quote_repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var quote = get_random_quote();

            var model = new QuotesViewModel{quote = quote};

            return View(model);
        }

        [HttpGet]
        public JsonResult RandomQuote()
        {
            var quote_model = get_random_quote();
            var view = this.RenderPartialViewToString("_QuoteSection", quote_model);
            return Json(new {view},JsonRequestBehavior.AllowGet);
        }

        QuoteModel get_random_quote()
        {
            var quote = quote_repository.get_random_quote();
            var quote_model = new QuoteModel{author = quote.author, quote = quote.message};
            return quote_model;
        }
    }
}
