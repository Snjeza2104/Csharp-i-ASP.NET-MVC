using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using knjiznica.Models;
using knjiznica.Models.DAL;

namespace knjiznica.Controllers
{
    public class KnjigaController : Controller
    {
        public ActionResult List()
        {
            List<Knjiga> lstKnjige = new List<Knjiga>();
            try
            {
                lstKnjige = Repozitorij.DohvatiKnjigu();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa knjiga! Opis: " + ex.Message;
            }
            return View(lstKnjige);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Knjiga(true));
        }

        [HttpPost]
        public ActionResult Create(Knjiga model)
        {
            try
            {
                Repozitorij.KreirajKnjigu(model);
                ViewBag.Message = "Knjiga je uspješno upisana!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa knjige! Opis: " + ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int knjigaID)
        {
            Knjiga knjiga = new Knjiga(true);
            try
            {
                knjiga = Repozitorij.DohvatiKnjigu(knjigaID);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja knjige! Opis: " + ex.Message;
            }
            return View(knjiga);
        }

        [HttpPost]
        public ActionResult Edit(Knjiga model)
        {
            try
            {
                Repozitorij.UrediKnjigu(model);
                ViewBag.Message = "Knjiga uspješno uređena!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja knjige. Opis: " + ex.Message;
            }
            return View(model);
        }

        public ActionResult Delete(int knjigaID)
        {
            try
            {
                Repozitorij.IzbrisiKnjigu(knjigaID);
                TempData["Message"] = "Knjiga uspješno izbrisana!";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Greška kod brisanja knjige! Opis: " + ex.Message;
            }
            return RedirectToAction("List");
        }
    }
}