using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sigurnost.Controllers
{
    public class SigurnostAkcijeController : Controller
    {
        // GET: SigurnostAkcije
        [Authorize]
        public ActionResult ZasticenaStranica()
        {
            return View();
        }
        public ActionResult NezasticenaStranica()
        {
            return View();
        }
    }
}