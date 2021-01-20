using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViseslojnaAplikacija.Models;
using ViseslojnaAplikacija.Models.DAL;

namespace ViseslojnaAplikacija.Controllers
{
    public class MasterDetailsController : Controller
    {
        // GET: MasterDetails
        public ActionResult List()
        {
            List<UpisiDetailModel> lstUpisiDetails = new List<UpisiDetailModel>();
            try
            {
                lstUpisiDetails = Repozitorij.UpisiMasterDetails();
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa polaznika! Opis:" + ex.Message;
            }
            return View(lstUpisiDetails);
        }
    }
}