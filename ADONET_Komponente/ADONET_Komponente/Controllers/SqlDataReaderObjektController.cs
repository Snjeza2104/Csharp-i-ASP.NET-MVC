using ADONET_Komponente.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADONET_Komponente.Controllers
{
    public class SqlDataReaderObjektController : Controller
    {
        // GET: SqlDataReaderObjekt
        public ActionResult Index()
        {
            //Kreiramo ConnectionString i Connection objekt
            List<Tecaj> lstTecajevi = new List<Tecaj>();
            //string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnStr"].ConnectionString;
            string connString = "Data Source =.\\SQLExpress; Initial Catalog = dbAlgebra10; Integrated Security = True;";
            using (SqlConnection conn=new SqlConnection(connString))
            {
                string cmdText = "SELECT * FROM tblTecajevi";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                //Izvršavamo komandu pozivom ExecuteReader metode koja kreira SqlDataReader objekt
                SqlDataReader reader = cmd.ExecuteReader();

                //Ako je pozivom metode kreiran SqlDataReader objekt
                if (reader != null)
                {
                    //i ako ima redaka za čitanje
                    if (reader.HasRows)
                    {
                        //Dok ima podataka u readeru, dodajemo ih u listu
                        while (reader.Read())
                        {
                            //Kreiramo novi Tecaj objekt
                            Tecaj tecaj = new Tecaj();

                            //Postavljamo mu svojstva
                            tecaj.Id = int.Parse(reader["IdTecaj"].ToString());
                            tecaj.Naziv = reader["Naziv"].ToString();
                            tecaj.Opis = reader["Opis"].ToString();

                            //Dodajemo tecaj u listu lstTecajevi
                            lstTecajevi.Add(tecaj);
                        }
                    }
                }
                reader.Close();
            }
            return View(lstTecajevi);
        }
    }
}