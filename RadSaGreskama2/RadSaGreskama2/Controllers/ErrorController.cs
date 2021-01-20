using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RadSaGreskama2.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string poruka)
        {
            if (TempData["err"] != null)
                ViewBag.error = TempData["err"];
            else
                ViewBag.error = poruka;
            return View();
        }
    }
}