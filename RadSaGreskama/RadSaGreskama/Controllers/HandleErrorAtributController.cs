using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RadSaGreskama.Models;

namespace RadSaGreskama.Controllers
{
    public class HandleErrorAtributController : Controller
    {
        // GET: HandleErrorAtribut
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

        [HandleError]
        [HttpPost]
        public ActionResult Dijeli(Kalkulator model)
        {
            model.Dijeli();
            return View(model);
        }
    }
}