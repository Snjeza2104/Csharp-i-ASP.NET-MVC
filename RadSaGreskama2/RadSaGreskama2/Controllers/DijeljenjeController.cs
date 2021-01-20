using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RadSaGreskama2.Controllers
{
    public class DijeljenjeController : Controller
    {
        // GET: Dijeljenje
        public ActionResult Dijeli()
        {
            try
            {
                double brojA = double.Parse(Request.QueryString["brojA"]);
                double brojB = double.Parse(Request.QueryString["brojB"]);
                double rezultat = brojA / brojB;
                ViewBag.Message = rezultat;
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Dogodila se greška! Detalji: " + ex.Message;
            }
            return View();
        }
    }
}