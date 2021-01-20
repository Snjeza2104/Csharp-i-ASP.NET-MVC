using ADO_NET_Komponente.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO_NET_Komponente.Controllers
{
    public class ADONETKomponenteController : Controller
    {
        // GET: ADONETKomponente
        public ActionResult List()
        {
            List<string> tecajNaziv = new List<string>();
            string connString = "Data Source =.\\SQLExpress; Initial Catalog = dbAlgebra10; Integrated Security = True;";
            using(SqlConnection conn=new SqlConnection(connString))
            {
                string cmdText = "SELECT Naziv FROM tblTecajevi";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string tecajnaziv = reader["Naziv"].ToString();
                            tecajNaziv.Add(tecajnaziv);
                        }
                    }
                }
                reader.Close();
            }
            return View(tecajNaziv);
        }
        public ActionResult Details()
        {
            List<Tecaj> lstTecajevi = new List<Tecaj>();
            string connString = "Data Source =.\\SQLExpress; Initial Catalog = dbAlgebra10; Integrated Security = True;";
            using(SqlConnection conn=new SqlConnection(connString))
            {
                string cmdText = "SELECT Naziv, Opis FROM tblTecajevi";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Tecaj tecaj = new Tecaj();
                            tecaj.Naziv = reader["Naziv"].ToString();
                            tecaj.Opis = reader["Opis"].ToString();

                            lstTecajevi.Add(tecaj);
                        }
                    }
                }reader.Close();
            }
            return View(lstTecajevi);
        }
    }
}