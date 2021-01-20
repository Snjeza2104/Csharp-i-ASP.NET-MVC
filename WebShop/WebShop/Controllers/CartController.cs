using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
   
    public class CartController : Controller
    {
        private WebShop_model db = new WebShop_model();
        public static List<Proizvodi> lstProizvodi = new List<Proizvodi>();
        // GET: Cart
        public ActionResult Index()
        {
            if (Session["Cart"] != null)
            {
                lstProizvodi = Session["Cart"] as List<Proizvodi>;
            }
            return View(lstProizvodi);
        }

        public ActionResult AddToCart(int id)
        {
            Proizvodi proizvod = db.Proizvodi.Find(id);
            lstProizvodi.Add(proizvod);

            //Listu proizvoda spremamo u Session objekt
            Session["Cart"] = lstProizvodi;

            if (proizvod == null)
            {
                return HttpNotFound();
            }

            var proizvodi = db.Proizvodi.Include(p => p.MjereProizvoda);
            return RedirectToAction(actionName: "Index", controllerName: "WebShop", routeValues: proizvodi.ToList());
        }

        public ActionResult RemoveFromCart(int index)
        {
            lstProizvodi = Session["Cart"] as List<Proizvodi>;
            lstProizvodi.RemoveAt(index);
            Session["Cart"] = lstProizvodi;
            return View("Index", lstProizvodi);
        }
    }
}