using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        /// <summary>
        /// Default sample
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to the StringTemplate ViewEngine Demo!";
            return View();
        }

        /// <summary>
        /// Return an alternate view path
        /// </summary>
        /// <returns></returns>
        public ActionResult Alternate()
        {
            return View("~/test/alternate");
            //return View("~test/alternate"); is also valid...
        }

        /// <summary>
        /// Return an alternate view path
        /// </summary>
        /// <returns></returns>
        public ActionResult Dynamic()
        {
            return View(new StringTemplateView("Template generated on the fly!"));
        }
    }
}
