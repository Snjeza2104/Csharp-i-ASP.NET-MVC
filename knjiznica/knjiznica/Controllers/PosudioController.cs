using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using knjiznica.Models;
using knjiznica.Models.DAL;

namespace knjiznica.Controllers
{
    public class PosudioController : Controller
    {
        public ActionResult List()
        {
            List<Posudio> lstposudio = new List<Posudio>();
            try
            {
                lstposudio = Repozitorij.DohvatiPosudio();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa! Opis: " + ex.Message;
            }
            return View(lstposudio);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Posudio(true));
        }

        [HttpPost]
        public ActionResult Create(Posudio model)
        {
            try
            {
                Repozitorij.KreirajPosudio(model);
                ViewBag.Message = "Uspješno upisano!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa! Opis: " + ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int posudjivacID, int knjigaID)
        {
            Posudio posudio = new Posudio(true);
            try
            {
                posudio = Repozitorij.DohvatiPosudio(posudjivacID, knjigaID);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja! Opis: " + ex.Message;
            }
            return View(posudio);
        }

        [HttpPost]
        public ActionResult Edit(Posudio model)
        {
            try
            {
                Repozitorij.UrediPosudio(model);
                ViewBag.Message = "Uspješno uređeno!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja. Opis: " + ex.Message;
            }
            return View(model);
        }

        public ActionResult Delete(int posudjivacID, int knjigaID)
        {
            try
            {
                Repozitorij.IzbrisiPosudio(posudjivacID, knjigaID);
                TempData["Message"] = "Uspješno izbrisano!";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Greška kod brisanja! Opis: " + ex.Message;
            }
            return RedirectToAction("List");
        }
    }
}