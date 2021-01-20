using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace SpajanjeNaBazu.Controllers
{
    public class ConnStrController : Controller
    {
        // GET: ConnStr
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConnectionWithAuth()
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
                    ViewBag.Message = "VEZA OTVORENA!";
                }
            }
            catch (SqlException sqlEx)
            {
                //U slučaju da konekcija nije uspjela, ispisujemo poruku o greški
                ViewBag.Message = "GREŠKA U SQL-U! OPIS: " + sqlEx.Message;
            }
            catch(Exception ex)
            {
                ViewBag.Message = "GREŠKA! OPIS: " + ex.Message;
            }
            finally
            {
                if (conn == null)
                {
                    ViewBag.Message += "<br>Veza ne postoji.";
                }
                else
                {
                    if(conn.State==ConnectionState.Open)
                    {
                        conn.Close();
                        ViewBag.Message += "<br>Veza je zatvorena!";
                    }
                    conn.Dispose();
                    conn = null;
                }
                
            }
            return View();
        }

        public ActionResult ConnectionSQLAuth()
        {
            string connStr = "Data Source=.\\SQLEXPRESS; Initial Catalog=dbAlgebra; uid=snjez; Password=SQL;";

            //Instanciramo SqlConnection objekt
            SqlConnection conn = null;

            //Kreiramo novu konekciju i pokušavamo je otvoriti
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();

                //Ako je konekcija otvorena, ispisujemo poruku na stranici
                if (conn.State == ConnectionState.Open)
                {
                    ViewBag.Message = "VEZA OTVORENA!";
                }
            }
            catch(SqlException sqlEx)//U slučaju greške u bazi ispisujemo poruku
            {
                ViewBag.Message = "Greška u SQL-u. Opis: " + sqlEx.Message;
            }
            catch(Exception ex) //U slučaju sistemske greške ispisujemo grešku
            {
                ViewBag.Message = "Greška! Opis: " + ex.Message;
            }
            finally
            {
                //U ovom bloku otpuštamo upotrebljene resurse
                if (conn == null)
                {
                    ViewBag.Message += "<br> VEZA NE POSTOJI";
                }
                else
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        ViewBag.Message += "<br> VEZA ZATVORENA!";
                    }
                    conn.Dispose();
                    conn = null;
                }
            }
            return View();
        }
    }
    }