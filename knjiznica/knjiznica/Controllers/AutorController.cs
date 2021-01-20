using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using knjiznica.Models;
using knjiznica.Models.DAL;

namespace knjiznica.Controllers
{
    public class AutorController : Controller
    {
        public ActionResult List()
        {
            List<Autor> lstAutori = new List<Autor>();
            try
            {
                lstAutori = Repozitorij.DohvatiAutore();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa autora! Opis: " + ex.Message;
            }
            return View(lstAutori);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Autor());
        }

        [HttpPost]
        public ActionResult Create(Autor model)
        {
            try
            {
                Repozitorij.KreirajAutora(model);
                ViewBag.Message = "Autor je uspješno upisan!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa autora! Opis: " + ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int autorID)
        {
            Autor autor = new Autor();
            try
            {
                autor = Repozitorij.DohvatiAutora(autorID);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja autora! Opis: " + ex.Message;
            }
            return View(autor);
        }

        [HttpPost]
        public ActionResult Edit(Autor model)
        {
            try
            {
                Repozitorij.UrediAutora(model);
                ViewBag.Message = "Autor uspješno uređen!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja autora. Opis: " + ex.Message;
            }
            return View(model);
        }
        public ActionResult Delete(int autorID)
        {
            try
            {
                Repozitorij.IzbrisiAutora(autorID);
                TempData["Message"] = "Autor uspješno izbrisan!";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Greška kod brisanja autora! Opis: " + ex.Message;
            }
            return RedirectToAction("List");
        }

    }
}