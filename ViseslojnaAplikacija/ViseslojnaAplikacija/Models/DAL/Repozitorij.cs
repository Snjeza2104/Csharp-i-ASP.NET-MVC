using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViseslojnaAplikacija.Models.DAL
{
    public class Repozitorij
    {
        public static DataSet ds { get; set; }
        private static string cs= "Data Source =.\\SQLExpress; Initial Catalog = dbAlgebra10; Integrated Security = True;";

        public static List<PolaznikModel> DohvatiPolaznike()
        {
            List<PolaznikModel> kolekcija = new List<PolaznikModel>();
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiPolaznike");
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                PolaznikModel polaznik = new PolaznikModel(false);
                polaznik.IdPolaznik = (int)row["IdPolaznik"];
                polaznik.Ime = row["Ime"].ToString();
                polaznik.Prezime = row["Prezime"].ToString();
                polaznik.Email = row["Email"].ToString();
                kolekcija.Add(polaznik);
            }
            return kolekcija;
        }
        public static PolaznikModel DohvatiPolaznika(int idPolaznik)
        {
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiPolaznika", idPolaznik);
            DataRow row = ds.Tables[0].Rows[0];

            PolaznikModel polaznik = new PolaznikModel(true);
            polaznik.IdPolaznik = (int)row["IdPolaznik"];
            polaznik.Ime = row["Ime"].ToString();
            polaznik.Prezime = row["Prezime"].ToString();
            polaznik.Email = row["Email"].ToString();
            polaznik.IdGrad = (int)row["IdGrad"];

            return polaznik;
        }
        public static void UrediPolaznika(PolaznikModel polaznik)
        {
            SqlHelper.ExecuteNonQuery(cs, "UrediPolaznika", polaznik.IdPolaznik, polaznik.Ime, polaznik.Prezime, polaznik.Email, polaznik.IdGrad);
        }
        public static object KreirajPolaznika(PolaznikModel polaznik)
        {
            var id = SqlHelper.ExecuteScalar(cs, "KreirajPolaznika", polaznik.Ime, polaznik.Prezime, polaznik.Email, polaznik.IdGrad);
            return id;
        }
        public static void IzbrisiPolaznika(int idPolaznik)
        {
            SqlHelper.ExecuteNonQuery(cs, "IzbrisiPolaznika", idPolaznik);
        }
        public static List<TecajModel> DohvatiTecajeve()
        {
            List<TecajModel> kolekcija = new List<TecajModel>();
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiTecajeve");
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                TecajModel tecaj = new TecajModel();
                tecaj.IdTecaj = (int)row["IdTecaj"];
                tecaj.Naziv = row["Naziv"].ToString();
                tecaj.Opis = row["Opis"].ToString();
                kolekcija.Add(tecaj);
            }
            return kolekcija;
        }
        public static TecajModel DohvatiTecaj(int idTecaj)
        {
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiTecaj", idTecaj);
            DataRow row = ds.Tables[0].Rows[0];
            TecajModel tecaj = new TecajModel();
            tecaj.IdTecaj = (int)row["IdTecaj"];
            tecaj.Naziv = row["Naziv"].ToString();
            tecaj.Opis = row["Opis"].ToString();

            return tecaj;
        }
        public static void UrediTecaj(TecajModel tecaj)
        {
            SqlHelper.ExecuteNonQuery(cs, "UrediTecaj", tecaj.IdTecaj, tecaj.Naziv, tecaj.Opis);
        }
        public static void KreirajTecaj(TecajModel tecaj)
        {
            SqlHelper.ExecuteNonQuery(cs, "KreirajTecaj", tecaj.Naziv, tecaj.Opis);
        }
        public static void IzbrisiTecaj(int idTecaj)
        {
            SqlHelper.ExecuteNonQuery(cs, "IzbrisiTecaj", idTecaj);
        }

        public static List<UpisiDetailModel> UpisiMasterDetails()
        {
            List<UpisiDetailModel> kolekcija = new List<UpisiDetailModel>();
            ds = SqlHelper.ExecuteDataset(cs, "UpisiMasterDetails");
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                UpisiDetailModel upis = new UpisiDetailModel();
                upis.Ime = row["Ime"].ToString();
                upis.Prezime = row["Prezime"].ToString();
                upis.Email = row["Email"].ToString();
                upis.Naziv = row["Naziv"].ToString();
                upis.Opis = row["Opis"].ToString();
                upis.DatumUpisa = DateTime.Parse(row["DatumUpisa"].ToString());
                kolekcija.Add(upis);
            }
            return kolekcija;
        }
        public static void KreirajUpis(PolaznikModel model, int idTecaj)
        {
            var idPolaznik = KreirajPolaznika(model);
            SqlHelper.ExecuteNonQuery(cs, "KreirajUpis", idTecaj, idPolaznik, DateTime.Now);
        }
    }
}