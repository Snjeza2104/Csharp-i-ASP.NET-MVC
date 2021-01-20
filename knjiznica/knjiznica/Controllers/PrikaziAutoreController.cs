using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using Microsoft.ApplicationBlocks.Data;
using knjiznica.Models;

namespace knjiznica.Controllers
{
    public class PrikaziAutoreController : Controller
    {
        public static DataSet ds { get; set; }
        public static DataSet ds2 { get; set; }
        public static DataSet ds3 { get; set; }
        public static DataSet ds4 { get; set; }
        private static string cs = "Data Source =.\\SQLExpress; Initial Catalog = knjiznica; Integrated Security = True;";
        public static List<Autor> lstAutori = new List<Autor>();
        public static List<Izdavac> lstIzdavaci = new List<Izdavac>();
        public static List<Knjiga> lstKnjige = new List<Knjiga>();
        public static List<Posudjivac> lstPosudjivac = new List<Posudjivac>();
        // GET: PrikaziAutore
        [HttpGet]
        public ActionResult PrikaziAutore()
        {
            lstAutori.Clear();
            ds = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM autor");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Autor autor = new Autor();
                autor.autorID = int.Parse(row["autorID"].ToString());
                autor.ime = row["ime"].ToString();
                autor.prezime = row["prezime"].ToString();
                lstAutori.Add(autor);
            }
            ViewBag.Autori = lstAutori;
            return View();
        }
        public ActionResult PrikaziIzdavace()
        {
            lstIzdavaci.Clear();
            ds2 = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM izdavac");
            foreach(DataRow redak in ds2.Tables[0].Rows)
            {
                Izdavac izdavac = new Izdavac();
                izdavac.izdavacID = int.Parse(redak["izdavacID"].ToString());
                izdavac.ime_izdavaca = redak["ime_izdavaca"].ToString();
                izdavac.broj_telefona = redak["broj_telefona"].ToString();
                izdavac.fax = redak["fax"].ToString();
                izdavac.email = redak["email"].ToString();
                lstIzdavaci.Add(izdavac);
            }
            ViewBag.Izdavaci = lstIzdavaci;
            return View();
        }
        public ActionResult PrikaziKnjige()
        {
            lstKnjige.Clear();
            ds3 = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM knjiga");
            foreach(DataRow redak in ds3.Tables[0].Rows)
            {
                Knjiga knjiga = new Knjiga();
                knjiga.knjigaID = int.Parse(redak["knjigaID"].ToString());
                knjiga.naslov = redak["naslov"].ToString();
                knjiga.izdavacID= int.Parse(redak["izdavacID"].ToString());
                knjiga.broj_stranica= int.Parse(redak["broj_stranica"].ToString());
                knjiga.cijena= int.Parse(redak["cijena"].ToString());
                knjiga.godina_izdanja= redak["godina_izdanja"].ToString();
                lstKnjige.Add(knjiga);
            }
            ViewBag.Knjige = lstKnjige;
            return View();
        }
        public ActionResult PrikaziPosudjivace()
        {
            lstPosudjivac.Clear();
            ds4 = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM posudjivac");
            foreach(DataRow redak in ds4.Tables[0].Rows)
            {
                Posudjivac posudjivac = new Posudjivac();
                posudjivac.posudjivacID = int.Parse(redak["posudjivacID"].ToString());
                posudjivac.prezime = redak["prezime"].ToString();
                posudjivac.ime = redak["ime"].ToString();
                posudjivac.mobitel = redak["mobitel"].ToString();
                posudjivac.email = redak["email"].ToString();
                lstPosudjivac.Add(posudjivac);
            }

            ViewBag.Posudjivaci = lstPosudjivac;
            return View();
        }
    }
}



