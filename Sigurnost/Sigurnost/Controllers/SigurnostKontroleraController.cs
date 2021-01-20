using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sigurnost.Controllers
{
    [Authorize]
    public class SigurnostKontroleraController : Controller
    {
        // GET: SigurnostKontrolera
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
    }
}