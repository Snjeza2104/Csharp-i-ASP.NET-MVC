using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RadSaGreskama2.Controllers
{
    public class ZbrajanjeController : Controller
    {
        // GET: Zbrajanje
        [HttpGet]
        public ActionResult Zbroj()
        {
            return View();
        }

        [HttpPost]
        [HandleError]
        public ActionResult Zbroj(int brojA, int brojB)
        {
            try
            {
                int rezultat = brojA + brojB;
                ViewBag.Rezultat = rezultat;
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Dogodila se greška! Detalji: " + ex.Message;
            }
            return View();
        }
    }
}