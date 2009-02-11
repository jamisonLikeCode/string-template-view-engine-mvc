using System;
using System.Web.Mvc;
using Antlr.StringTemplate;

namespace MvcDemo
{
    /// <summary>
    /// The ViewEngine for StringTemplate Views
    /// </summary>
    public class StringTemplateViewEngine : IViewEngine
    {
        #region Properties
        /// <summary>
        /// The loader object for the templates
        /// </summary>
        public static FileSystemTemplateLoader Loader { get; private set; }

        /// <summary>
        /// The default group that will hold the cached templates
        /// </summary>
        public static StringTemplateGroup Group { get; private set; }
        #endregion

        #region .ctors
        /// <summary>
        /// Creates a new instance of the StringTemplateViewEngine
        /// </summary>
        /// <param name="viewPath">The physical path to the root views directory</param>
        public StringTemplateViewEngine(string viewPath)
        {
            Loader = new FileSystemTemplateLoader(viewPath);
            Group = new StringTemplateGroup("views", Loader);
        }
        #endregion

        #region IViewEngine Members

        /// <summary>
        /// Returns null. Partial views don't exist in StringTemplate
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="partialViewName"></param>
        /// <param name="useCache"></param>
        /// <returns></returns>
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return null;
        }

        /// <summary>
        /// Locates a view
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="viewName"></param>
        /// <param name="masterName"></param>
        /// <param name="useCache"></param>
        /// <returns></returns>
        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            //load template from loader
            StringTemplate template;
            if (viewName.StartsWith("~"))
            {
                template = Group.GetInstanceOf(viewName.Replace("~", "")); //viewName.Substring(2, viewName.Length - 2)
            }
            else
            {
                var controllerName = controllerContext.Controller.GetType().Name.Replace("Controller", "");
                template = Group.GetInstanceOf(string.Format("{0}/{1}", controllerName, viewName));
            }

            //return view result
            return new ViewEngineResult(new StringTemplateView(template), this);
        }

        /// <summary>
        /// Not used. String templates are cached by the static group object.
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="view"></param>
        public void ReleaseView(ControllerContext controllerContext, IView view) { }
        #endregion
    }
}
