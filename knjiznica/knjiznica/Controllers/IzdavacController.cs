using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using knjiznica.Models;
using knjiznica.Models.DAL;

namespace knjiznica.Controllers
{
    public class IzdavacController : Controller
    {
        // GET: Izdavac
        public ActionResult List()
        {
            List<Izdavac> lstIzdavaci = new List<Izdavac>();
            try
            {
                lstIzdavaci = Repozitorij.DohvatiIzdavace();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa izdavača! Opis: " + ex.Message;
            }
            return View(lstIzdavaci);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Izdavac());
        }

        [HttpPost]
        public ActionResult Create(Izdavac model)
        {
            try
            {
                Repozitorij.KreirajIzdavaca(model);
                ViewBag.Message = "Izdavač je uspješno upisan!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa izdavača! Opis: " + ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int izdavacID)
        {
            Izdavac izdavac = new Izdavac();
            try
            {
                izdavac = Repozitorij.DohvatiIzdavaca(izdavacID);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja izdavača! Opis: " + ex.Message;
            }
            return View(izdavac);
        }

        [HttpPost]
        public ActionResult Edit(Izdavac model)
        {
            try
            {
                Repozitorij.UrediIzdavaca(model);
                ViewBag.Message = "Izdavač uspješno uređen!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja izdavača. Opis: " + ex.Message;
            }
            return View(model);
        }
        public ActionResult Delete(int izdavacID)
        {
            try
            {
                Repozitorij.IzbrisiIzdavaca(izdavacID);
                TempData["Message"] = "Izdavač uspješno izbrisan!";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Greška kod brisanja izdavača! Opis: " + ex.Message;
            }
            return RedirectToAction("List");
        }

    }
}