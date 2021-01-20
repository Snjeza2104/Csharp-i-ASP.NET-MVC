using RadSaGreskama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RadSaGreskama.Controllers
{
    public class BezHvatanjaKalkulatorController : Controller
    {
        // GET: BezHvatanjaKalkulator
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
    }
}