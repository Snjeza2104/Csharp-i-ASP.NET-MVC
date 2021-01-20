using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace ADONET_Komponente.Controllers
{
    public class SqlConnectionObjektController : Controller
    {
        // GET: SqlConnectionObjekt
        public ActionResult Index()
        {
            //Prvo moramo sastaviti ConnectionString
            string connString = "Data Source =.\\SQLExpress; Initial Catalog = dbAlgebra; Integrated Security = True;";

            //Zatim instanciramo SqlConnection objekt
            SqlConnection conn = new SqlConnection(connString);

            //otvaramo vezu s bazom
            try
            {
                conn.Open();
                //Ako je veza otvorena, uspjeli smo se spojiti
                if (conn.State == ConnectionState.Open)
                {
                    Response.Write("Konekcija je uspjela.");
                }
            }
            catch (SqlException sqlEx) {
                //U slučaju da konekcija nije uspjela, ispisujemo poruku o greški
                Response.Write(sqlEx.Message);
            }
            finally {
                conn.Close();
            }
            return View();
        }
    }
}