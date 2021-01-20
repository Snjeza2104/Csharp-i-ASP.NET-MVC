using Microsoft.ApplicationBlocks.Data;
using SQLHelperKlasa.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.Mvc;

namespace SQLHelperKlasa.Controllers
{
    public class GradoviDrzaveController : Controller
    {
        public static DataSet ds { get; set; }
        private static string cs = "Data Source =.\\SQLExpress; Initial Catalog = dbAlgebra10; Integrated Security = True;";
        public static List<DrzavaModel> lstDrzave = new List<DrzavaModel>();
        public static List<GradModel> lstGradovi = new List<GradModel>();
       
        // GET: GradoviDrzave
        [HttpGet]
        public ActionResult GradoviDrzave()
        {
            lstDrzave.Clear();
            ds = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM tblDrzave");

            foreach(DataRow row in ds.Tables[0].Rows)
            {
                DrzavaModel drzava = new DrzavaModel();
                drzava.IdDrzava = int.Parse(row["IdDrzava"].ToString());
                drzava.Naziv = row["Naziv"].ToString();
                lstDrzave.Add(drzava);
            }
            ViewBag.Drzave = new SelectList(lstDrzave, "IdDrzava", "Naziv");
            
            return View();
        }

        [HttpPost]
        public ActionResult GradoviDrzave(int idDrzava, int? idGrad)
        {
            lstGradovi.Clear();
            ds = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM tblGradovi WHERE IdDrzava=" + idDrzava);

            foreach(DataRow row in ds.Tables[0].Rows)
            {
                GradModel grad = new GradModel();
                grad.IdGrad = int.Parse(row["IdGrad"].ToString());
                grad.Naziv = row["Naziv"].ToString();
                lstGradovi.Add(grad);
            }
            ViewBag.Drzave = new SelectList(lstDrzave, "IdDrzava", "Naziv");
            ViewBag.Gradovi = new SelectList(lstGradovi, "IdGrad", "Naziv");

            if (idGrad != null)
            {
                return RedirectToAction(
                    actionName: "DohvatiPolaznikePoGradu",
                    controllerName: "Polaznici",
                    routeValues: new { idGrad = idGrad });
            }
            return View();
        }
       
    }
}