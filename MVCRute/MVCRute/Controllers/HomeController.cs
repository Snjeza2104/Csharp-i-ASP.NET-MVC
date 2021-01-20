using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRute.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult DefaultnaRuta()
        {
            List<string> stringovi = new List<string>();
            stringovi.Add("Čovjek");
            stringovi.Add("Životinje");
            stringovi.Add("Biljke");
            ViewBag.str = stringovi;
            return View();
        }

        public ActionResult VisestrukiParametri(string param1, string param2)
        {
            ViewBag.Param1 = param1;
            ViewBag.Param2 = param2;
            return View();
        }
    }
}