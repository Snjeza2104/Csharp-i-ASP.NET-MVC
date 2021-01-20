using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RadSaGreskama2.Controllers
{
    public class KorijenController : Controller
    {
        // GET: Korijen
        public ActionResult Korijen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Korijen(double broj)
        {
            try
            {
                broj= Math.Sqrt(broj);
                ViewBag.Rezultat = broj;
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Dogodila se greška! Detalji: " + ex.Message;
            }
            return View();
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");
            filterContext.Result = new ViewResult()
            {
                ViewName = "ErrorMessage",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}