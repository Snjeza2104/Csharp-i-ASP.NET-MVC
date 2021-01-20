using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViseslojnaAplikacija.Models;
using ViseslojnaAplikacija.Models.DAL;

namespace ViseslojnaAplikacija.Controllers
{
    public class UpisiController : Controller
    {
        // GET: Upisi
        [HttpGet]
        public ActionResult Index()
        {
            List<TecajModel> lstTecajevi = new List<TecajModel>();
            try
            {
                lstTecajevi = Repozitorij.DohvatiTecajeve();
                ViewBag.Tecajevi = new SelectList(lstTecajevi, "IdTecaj", "Naziv");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa tecaja! Opis: " + ex.Message;
            }
            return View(new PolaznikModel(true));
        }

        [HttpPost]
        public ActionResult Index(PolaznikModel model, int idTecaj)
        {
            List<TecajModel> lstTecajevi = new List<TecajModel>();
            try
            {
                Repozitorij.KreirajUpis(model, idTecaj);
                lstTecajevi = Repozitorij.DohvatiTecajeve();
                ViewBag.Tecajevi = new SelectList(lstTecajevi, "IdTecaj", "Naziv");
                ViewBag.Message = "Upis uspješno kreiran!";
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa tecaja! Opis: " + ex.Message;
            }
            return View(new PolaznikModel(true));
        }
    }
}