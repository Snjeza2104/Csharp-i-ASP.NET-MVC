using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RadSaGreskama.Models;

namespace RadSaGreskama.Controllers
{
    public class TryCatchKalkulatorController : Controller
    {
        // GET: TryCatchKalkulator
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
            try
            {
                model.Dijeli();
            }
            catch
            {
                return View("Error");
            }
            return View("Index", model);
        }
    }
}