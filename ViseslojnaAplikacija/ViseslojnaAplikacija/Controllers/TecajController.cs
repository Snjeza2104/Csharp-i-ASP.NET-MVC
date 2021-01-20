using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViseslojnaAplikacija.Models;
using ViseslojnaAplikacija.Models.DAL;

namespace ViseslojnaAplikacija.Controllers
{
    public class TecajController : Controller
    {
        // GET: Tecaj
        public ActionResult List()
        {
            List<TecajModel> lstTecajevi = new List<TecajModel>();
            try
            {
                lstTecajevi = Repozitorij.DohvatiTecajeve();
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa tecaja! Opis: " + ex.Message;
            }
            return View(lstTecajevi);
        }

        [HttpGet]
        public ActionResult Details(int idTecaj)
        {
            TecajModel tecaj = new TecajModel();
            try
            {
                tecaj = Repozitorij.DohvatiTecaj(idTecaj);
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja tečaja! Opis: " + ex.Message;
            }
            return View(tecaj);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new TecajModel());
        }

        [HttpPost]
        public ActionResult Create(TecajModel model)
        {
            try
            {
                Repozitorij.KreirajTecaj(model);
                ViewBag.Message = "Tečaj uspješno upisan!";
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod upisa tečaja! Opis: " + ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int idTecaj)
        {
            TecajModel tecaj = new TecajModel();
            try
            {
                tecaj = Repozitorij.DohvatiTecaj(idTecaj);
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja tečaja! Opis: " + ex.Message;
            }
            return View(tecaj);
        }

        [HttpPost]
        public ActionResult Edit(TecajModel model)
        {
            try
            {
                Repozitorij.UrediTecaj(model);
                ViewBag.Message = "Tečaj uspješno uređen!";
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja tečaja! Opis: " + ex.Message;
            }
            return View(model);
        }

        public ActionResult Delete(int idTecaj)
        {
            try
            {
                Repozitorij.IzbrisiTecaj(idTecaj);
                ViewBag.Message = "Tečaj je uspješno izbrisan!";
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Grešks kod brisanja tečaja! Opis: " + ex.Message;
            }
            return RedirectToAction("List");
        }
    }
}