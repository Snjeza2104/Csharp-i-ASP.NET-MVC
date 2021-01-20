using Microsoft.ApplicationBlocks.Data;
using SQLHelperKlasa.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace SQLHelperKlasa.Controllers
{
    public class PolazniciController : Controller
    {
        public static DataSet ds { get; set; }
        private static string cs = "Data Source =.\\SQLExpress; Initial Catalog = dbAlgebra10; Integrated Security = True;";
        // GET: Polaznici
        public ActionResult DohvatiPolaznikePoGradu(int? idGrad)
        {
            if (idGrad != null)
            {
                ds = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM tblPolaznici " +
                    "WHERE IdGrad=" + idGrad);
                List<PolaznikModel> lstPolaznici = new List<PolaznikModel>();
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    PolaznikModel polaznik = new PolaznikModel();
                    polaznik.IdPolaznik = int.Parse(row["IdPolaznik"].ToString());
                    polaznik.Ime = row["Ime"].ToString();
                    polaznik.Prezime = row["Prezime"].ToString();
                    polaznik.Email = row["Email"].ToString();
                    lstPolaznici.Add(polaznik);
                }
                ViewBag.Polaznici = lstPolaznici;
                if (lstPolaznici.Count < 1)
                {
                    ViewBag.Message = "U odabranom gradu nema polaznika!";
                }
                return View("Polaznici");
            }
            return View();
        }
    }
}