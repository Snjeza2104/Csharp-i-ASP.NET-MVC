using Fakultet2.Kolegij2Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fakultet2.Controllers
{
    public class KolegijiWSController : Controller
    {
        // GET: KolegijiWS
        public ActionResult Index()
        {
            Kolegij2ServiceClient klijent = new Kolegij2ServiceClient();
            List<Kolegij> kolegiji = klijent.DohvatiKolegije().ToList();
            return View(kolegiji);
        }
        public ActionResult Details(int id)
        {
            Kolegij2ServiceClient klijent = new Kolegij2ServiceClient();
            Kolegij kolegij = klijent.DohvatiKolegij(id);
            return View(kolegij);
        }
    }
}