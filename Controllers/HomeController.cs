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
            // will look for a string template using the standard 
            // MVC convention of /views/controller/action
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
            return View(new StringTemplateView("This template was generated on the fly, and does not exist on disk."));
        }
    }
}
