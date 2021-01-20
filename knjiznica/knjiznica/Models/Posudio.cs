using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace knjiznica.Models
{
    public class Posudio
    {
        public int posudjivacID { get; set; }
        public int knjigaID { get; set; }
        public DateTime datum_posudbe { get; set; }
        public List<Posudjivac> lstPosudjivaci { get; set; }
        public List<Knjiga> lstKnjige { get; set; }
        public static DataSet ds { get; set; }
        public static DataSet ds2 { get; set; }
        private static string cs = "Data Source =.\\SQLExpress; Initial Catalog = knjiznica; Integrated Security = True;";

        public Posudio()
        {/*
            lstPosudjivaci = new List<Posudjivac>();
            ds = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM posudjivac");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Posudjivac posudjivac = new Posudjivac();
                posudjivac.posudjivacID = int.Parse(row["posudjivacID"].ToString());
                posudjivac.prezime = row["prezime"].ToString();
                posudjivac.ime = row["ime"].ToString();
                posudjivac.mobitel = row["mobitel"].ToString();
                posudjivac.email = row["email"].ToString();
                lstPosudjivaci.Add(posudjivac);
            }
            lstKnjige = new List<Knjiga>();
            ds2 = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM knjiga");
            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                Knjiga knjiga = new Knjiga();
                knjiga.knjigaID = int.Parse(row["knjigaID"].ToString());
                knjiga.naslov = row["naslov"].ToString();
                knjiga.izdavacID = int.Parse(row["izdavacID"].ToString());
                knjiga.broj_stranica = int.Parse(row["broj_stranica"].ToString());
                knjiga.cijena = int.Parse(row["cijena"].ToString());
                knjiga.godina_izdanja = row["godina_izdanja"].ToString();
                lstKnjige.Add(knjiga);
            }*/

        }
        public Posudio(bool isSingle)
        {
            if (isSingle)
            {
                lstPosudjivaci = new List<Posudjivac>();
                ds = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM posudjivac");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Posudjivac posudjivac = new Posudjivac();
                    posudjivac.posudjivacID = int.Parse(row["posudjivacID"].ToString());
                    posudjivac.prezime = row["prezime"].ToString();
                    posudjivac.ime = row["ime"].ToString();
                    posudjivac.mobitel = row["mobitel"].ToString();
                    posudjivac.email = row["email"].ToString();
                    lstPosudjivaci.Add(posudjivac);
                }
                lstKnjige = new List<Knjiga>();
                ds2 = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM knjiga");
                foreach (DataRow row in ds2.Tables[0].Rows)
                {
                    Knjiga knjiga = new Knjiga();
                    knjiga.knjigaID = int.Parse(row["knjigaID"].ToString());
                    knjiga.naslov = row["naslov"].ToString();
                    knjiga.izdavacID = int.Parse(row["izdavacID"].ToString());
                    knjiga.broj_stranica = int.Parse(row["broj_stranica"].ToString());
                    knjiga.cijena = int.Parse(row["cijena"].ToString());
                    knjiga.godina_izdanja = row["godina_izdanja"].ToString();
                    lstKnjige.Add(knjiga);
                }
            }
        }
    }
}