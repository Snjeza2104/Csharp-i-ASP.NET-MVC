//using RadSaGreskama2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RadSaGreskama2.Controllers
{
    public class KalkulatorController : Controller
    {
        // GET: Kalkulator
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(double? brojA, double? brojB, char? operacija)
        {
            if (!brojA.HasValue || !brojB.HasValue)
                return RedirectToAction(
                    actionName: "Index",
                    controllerName: "Error",
                    routeValues: new { poruka = "Niste proslijedili sve brojeve." });
            double rezultat;
            switch (operacija.Value)
            {
                case '+':
                    rezultat = brojA.Value + brojB.Value;
                    break;
                case '-':
                    rezultat = brojA.Value - brojB.Value;
                    break;
                case '*':
                    rezultat = brojA.Value * brojB.Value;
                    break;
                case '/':
                    rezultat = brojA.Value / brojB.Value;
                    break;
                default: TempData["err"] = "Kriva računska operacija!";
                    return RedirectToAction(controllerName: "Error", actionName: "Index");
            }
            ViewBag.a = brojA.Value;
            ViewBag.b = brojB.Value;
            ViewBag.rezultat = rezultat.ToString("n2");
            ViewData["operacija"] = operacija.Value;
            return View("Index");
        }
    }
}