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
    public class WebShopController : Controller
    {
        // GET: WebShop
        private WebShop_model db = new WebShop_model();

        //GET: Proizvodi
        public ActionResult Index()
        {
            var proizvodi = db.Proizvodi.Include(p => p.MjereProizvoda);
            return View(proizvodi.ToList());
        }
    }
}