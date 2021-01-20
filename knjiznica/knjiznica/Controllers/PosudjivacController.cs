using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using knjiznica.Models;
using knjiznica.Models.DAL;

namespace knjiznica.Controllers
{
    public class PosudjivacController : Controller
    {
        // GET: Izdavac
        public ActionResult List()
        {
            List<Posudjivac> lstPosudjivaci = new List<Posudjivac>();
            try
            {
                lstPosudjivaci = Repozitorij.DohvatiPosudjivace();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa posuđivača! Opis: " + ex.Message;
            }
            return View(lstPosudjivaci);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Posudjivac());
        }

        [HttpPost]
        public ActionResult Create(Posudjivac model)
        {
            try
            {
                Repozitorij.KreirajPosudjivaca(model);
                ViewBag.Message = "Posuđivač je uspješno upisan!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa posuđivača! Opis: " + ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int posudjivacID)
        {
            Posudjivac posudjivac = new Posudjivac();
            try
            {
                posudjivac = Repozitorij.DohvatiPosudjivaca(posudjivacID);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja posuđivača! Opis: " + ex.Message;
            }
            return View(posudjivac);
        }

        [HttpPost]
        public ActionResult Edit(Posudjivac model)
        {
            try
            {
                Repozitorij.UrediPosudjivaca(model);
                ViewBag.Message = "Posuđivač uspješno uređen!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja posuđivača. Opis: " + ex.Message;
            }
            return View(model);
        }
        public ActionResult Delete(int posudjivacID)
        {
            try
            {
                Repozitorij.IzbrisiPosudjivaca(posudjivacID);
                TempData["Message"] = "Posuđivač uspješno izbrisan!";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Greška kod brisanja posuđivača! Opis: " + ex.Message;
            }
            return RedirectToAction("List");
        }

    }
}