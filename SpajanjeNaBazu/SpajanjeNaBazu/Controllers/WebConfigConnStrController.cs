using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpajanjeNaBazu.Controllers
{
    public class WebConfigConnStrController : Controller
    {
        // GET: WebConfigConnStr
        public ActionResult ConnectionSQLAuth()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnStrSQL"].ConnectionString;

            //Instanciramo SqlConnection objekt
            SqlConnection conn = null;
            //Kreiramo novu konekciju i pokušavamo je otvoriti
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                //Ako je konekcija otvorena, ispisujemo poruku na stranici
                if (conn.State == ConnectionState.Open)
                {
                    ViewBag.Message = "VEZA OTVORENA";
                }
            }
            catch (SqlException sqlEx) //U slučaju greške u bazi ispisujemo grešku
            {
                ViewBag.Message = "GREŠKA U SQL-u! Opis: " + sqlEx.Message;
            }
            catch (Exception ex) //U slučaju sistemske greške, ispisujemo grešku
            {
                ViewBag.Message = "GREŠKA! OPIS: " + ex.Message;
            }
            finally
            {
                //U finaly bloku otpuštamo upotrebljene resurse
                if (conn == null)
                {
                    ViewBag.Message += "<br>VEZA NE POSTOJI!";
                }
                else
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        ViewBag.Message += "<br>VEZA ZATVORENA!";
                    }
                    conn.Dispose();
                    conn = null;
                }
            }
            return View();
        }

        //GET: WebConfigConnStr
        public ActionResult ConnectionWinAuth()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnStrWin"].ConnectionString;

            //Instanciramo SQL Connection objekt
            SqlConnection conn = null;
            //Kreiramo novu konekciju i pokušavamo ju otvoriti
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                //Ako je konekcija otvorena, ispisujemo poruku na stranici
                if (conn.State == ConnectionState.Open)
                {
                    ViewBag.Message = "VEZA OTVORENA!";
                }
            }
            catch(SqlException sqlEx) //U slučaju greške u bazi ispisujemo grešku
            {
                ViewBag.Message = "GREŠKA U SQL-u! OPIS: " + sqlEx.Message;
            }
            catch(Exception ex)
            {
                ViewBag.Message = "GREŠKA! OPIS: " + ex.Message;
            }
            finally
            {
                //U finally bloku otpuštamo upotrebljene resurse
                if (conn == null)
                {
                    ViewBag.Message += " <br>VEZA NE POSTOJI!";
                }
                else
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        ViewBag.Message += "<br>VEZA ZATVORENA!";
                    }
                    conn.Dispose();
                    conn = null;
                }
            }
            return View();
        }
    }
}