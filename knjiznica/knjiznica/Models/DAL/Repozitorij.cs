using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using knjiznica.Models;

namespace knjiznica.Models.DAL
{
    public class Repozitorij
    {
        public static DataSet ds { get; set; }
        public static DataSet ds3 { get; set; }
        private static string cs = "Data Source =.\\SQLExpress; Initial Catalog = knjiznica; Integrated Security = True;";

        public static List<Autor> DohvatiAutore()
        {
            List<Autor> autori = new List<Autor>();
            ds = SqlHelper.ExecuteDataset(cs, "dohvatiAutore");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Autor autor = new Autor();
                autor.autorID = (int)row["autorID"];
                autor.prezime = row["prezime"].ToString();
                autor.ime = row["ime"].ToString();
                autori.Add(autor);
            }
            return autori;
        }

        public static List<Izdavac> DohvatiIzdavace()
        {
            List<Izdavac> izdavaci = new List<Izdavac>();
            ds = SqlHelper.ExecuteDataset(cs, "dohvatiIzdavace");
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Izdavac izdavac = new Izdavac();
                izdavac.izdavacID = (int)row["izdavacID"];
                izdavac.ime_izdavaca = row["ime_izdavaca"].ToString();
                izdavac.broj_telefona = row["broj_telefona"].ToString();
                izdavac.fax = row["fax"].ToString();
                izdavac.email = row["email"].ToString();
                izdavaci.Add(izdavac);
            }
            return izdavaci;

        }

        public static List<Posudjivac> DohvatiPosudjivace()
        {
            List<Posudjivac> posudjivaci = new List<Posudjivac>();
            ds = SqlHelper.ExecuteDataset(cs, "dohvatiPosudjivace");
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Posudjivac posudjivac = new Posudjivac();
                posudjivac.posudjivacID = (int)row["posudjivacID"];
                posudjivac.prezime = row["prezime"].ToString();
                posudjivac.ime = row["ime"].ToString();
                posudjivac.mobitel = row["mobitel"].ToString();
                posudjivac.email = row["email"].ToString();
                posudjivaci.Add(posudjivac);
            }
            return posudjivaci;
        }

        public static List<Knjiga> DohvatiKnjigu()
        {
            List<Knjiga> knjige = new List<Knjiga>();
            ds = SqlHelper.ExecuteDataset(cs, "dohvatiKnjige");
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Knjiga knjiga = new Knjiga();
                knjiga.knjigaID = (int)row["knjigaID"];
                knjiga.naslov = row["naslov"].ToString();
                knjiga.izdavacID = (int)row["izdavacID"];
                knjiga.broj_stranica = (int)row["broj_stranica"];
                knjiga.cijena = (int)row["cijena"];
                knjiga.godina_izdanja = row["godina_izdanja"].ToString();
                knjige.Add(knjiga);

            }
            return knjige;
        }
        public static List<Posudio> DohvatiPosudio()
        {
            List<Posudio> lstposudio = new List<Posudio>();
            ds3 = SqlHelper.ExecuteDataset(cs, "dohvatiPosudio");
            foreach(DataRow row in ds3.Tables[0].Rows)
            {
                Posudio posudio = new Posudio();
                posudio.posudjivacID = (int)row["posudjivacID"];
                posudio.knjigaID = (int)row["knjigaID"];
                posudio.datum_posudbe = (DateTime)row["datum_upisa"];
                lstposudio.Add(posudio);
            }
            return lstposudio;
        }

        public static Autor DohvatiAutora(int autorID)
        {
            ds = SqlHelper.ExecuteDataset(cs, "dohvatiAutora", autorID);
            DataRow row = ds.Tables[0].Rows[0];
            Autor autor = new Autor();
            autor.autorID = (int)row["autorID"];
            autor.prezime = row["prezime"].ToString();
            autor.ime = row["ime"].ToString();
            return autor;
        }

        public static Izdavac DohvatiIzdavaca(int izdavacID)
        {
            ds = SqlHelper.ExecuteDataset(cs, "dohvatiIzdavaca", izdavacID);
            DataRow row = ds.Tables[0].Rows[0];
            Izdavac izdavac = new Izdavac();
            izdavac.izdavacID = (int)row["izdavacID"];
            izdavac.ime_izdavaca = row["ime_izdavaca"].ToString();
            izdavac.broj_telefona = row["broj_telefona"].ToString();
            izdavac.fax = row["fax"].ToString();
            izdavac.email = row["email"].ToString();
            return izdavac;
        }
        public static Posudjivac DohvatiPosudjivaca(int posudjivacID)
        {
            ds = SqlHelper.ExecuteDataset(cs, "dohvatiPosudjivaca", posudjivacID);
            DataRow row = ds.Tables[0].Rows[0];
            Posudjivac posudjivac = new Posudjivac();
            posudjivac.posudjivacID = (int)row["posudjivacID"];
            posudjivac.prezime = row["prezime"].ToString();
            posudjivac.ime = row["ime"].ToString();
            posudjivac.mobitel = row["mobitel"].ToString();
            posudjivac.email = row["email"].ToString();
            return posudjivac;
        }

        public static Knjiga DohvatiKnjigu(int knjigaID)
        {
            ds = SqlHelper.ExecuteDataset(cs, "dohvatiKnjigu", knjigaID);
            DataRow row = ds.Tables[0].Rows[0];
            Knjiga knjiga = new Knjiga();
            knjiga.knjigaID = (int)row["knjigaID"];
            knjiga.naslov = row["naslov"].ToString();
            knjiga.izdavacID = (int)row["izdavacID"];
            knjiga.broj_stranica = (int)row["broj_stranica"];
            knjiga.cijena = (int)row["cijena"];
            knjiga.godina_izdanja = row["godina_izdanja"].ToString();
            return knjiga;
        }

        public static Posudio DohvatiPosudio(int posudjivacID, int knjigaID)
        {
            ds = SqlHelper.ExecuteDataset(cs, "dohvatiPosudio2", posudjivacID, knjigaID);
            DataRow row = ds.Tables[0].Rows[0];
            Posudio posudio = new Posudio();
            posudio.posudjivacID = (int)row["posudjivacID"];
            posudio.knjigaID = (int)row["knjigaID"];
            posudio.datum_posudbe = (DateTime)row["datum_upisa"];
            return posudio;
        }

        public static void UrediAutora(Autor autor)
        {
            SqlHelper.ExecuteNonQuery(cs, "urediAutora", autor.autorID, autor.prezime, autor.ime);
        }

        public static void UrediIzdavaca(Izdavac izdavac)
        {
            SqlHelper.ExecuteNonQuery(cs, "urediIzdavaca", izdavac.izdavacID, izdavac.ime_izdavaca, izdavac.broj_telefona, izdavac.fax, izdavac.email);
        }

        public static void UrediPosudjivaca(Posudjivac posudjivac)
        {
            SqlHelper.ExecuteNonQuery(cs, "urediPosudjivaca", posudjivac.posudjivacID, posudjivac.prezime, posudjivac.ime, posudjivac.mobitel, posudjivac.email);
        }

        public static void UrediKnjigu(Knjiga knjiga)
        {
            SqlHelper.ExecuteNonQuery(cs, "urediKnjigu", knjiga.knjigaID, knjiga.naslov, knjiga.izdavacID, knjiga.broj_stranica, knjiga.cijena, knjiga.godina_izdanja);
        }

        public static void UrediPosudio(Posudio posudio)
        {
            SqlHelper.ExecuteNonQuery(cs, "urediPosudio", posudio.posudjivacID, posudio.knjigaID, posudio.datum_posudbe);
        }

        public static object KreirajAutora(Autor autor)
        {
            var id = SqlHelper.ExecuteScalar(cs, "upisAutora", autor.prezime, autor.ime);
            return id;
        }

        public static object KreirajIzdavaca(Izdavac izdavac)
        {
            var id = SqlHelper.ExecuteScalar(cs, "upisIzdavaca", izdavac.ime_izdavaca, izdavac.broj_telefona, izdavac.fax, izdavac.email);
            return id;
        }

        public static object KreirajPosudjivaca(Posudjivac posudjivac)
        {
            var id = SqlHelper.ExecuteScalar(cs, "upisPosudjivaca", posudjivac.prezime, posudjivac.ime, posudjivac.mobitel, posudjivac.email);
            return id;
        }

        public static object KreirajKnjigu(Knjiga knjiga)
        {
            var id = SqlHelper.ExecuteScalar(cs, "upisKnjige", knjiga.naslov, knjiga.izdavacID, knjiga.broj_stranica, knjiga.cijena, knjiga.godina_izdanja);
            return id;
        }

        public static object KreirajPosudio(Posudio posudio)
        {
            return SqlHelper.ExecuteScalar(cs, "upisPosudio", posudio.posudjivacID, posudio.knjigaID, posudio.datum_posudbe);
            
        }

        public static void IzbrisiAutora(int autorID)
        {
            SqlHelper.ExecuteNonQuery(cs, "obrisiAutora", autorID);
        }

        public static void IzbrisiIzdavaca(int izdavacID)
        {
            SqlHelper.ExecuteNonQuery(cs, "obrisiIzdavaca", izdavacID);
        }

        public static void IzbrisiPosudjivaca(int posudjivacID)
        {
            SqlHelper.ExecuteNonQuery(cs, "obrisiPosudjivaca", posudjivacID);
        }

        public static void IzbrisiKnjigu(int knjigaID)
        {
            SqlHelper.ExecuteNonQuery(cs, "obrisiKnjigu", knjigaID);
        }

        public static void IzbrisiPosudio(int posudjivacID, int knjigaID)
        {
            SqlHelper.ExecuteNonQuery(cs, "obrisiPosudio", posudjivacID, knjigaID);
        }
    }
}
