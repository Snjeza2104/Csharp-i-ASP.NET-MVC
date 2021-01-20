using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RadSaGreskama.Models;

namespace RadSaGreskama.Controllers
{
    public class PremoscivanjeKalkulatoraController : Controller
    {
        // GET: PremoscivanjeKalkulatora
        public ActionResult Index()
        {
            //Postavljamo model na bezazlene vrijednosti
            Kalkulator model = new Kalkulator
            {
                PrviBroj = 0,
                DrugiBroj = 0
            };
            return View(model);
        }
        [HttpPost]
        public ViewResult Dijeli(Kalkulator model)
        {
            model.Dijeli();
            return View("Index", model);
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