using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalneGreske.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string rijec = "Neka riječ";
            int broj = int.Parse(rijec);
            return View();
        }
    }
}