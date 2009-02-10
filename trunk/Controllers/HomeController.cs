using System.Web.Mvc;

namespace STViewEngine.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to the StringTemplate ViewEngine Demo!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
