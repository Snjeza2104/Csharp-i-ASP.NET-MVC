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
    public class Knjiga
    {
        public int knjigaID { get; set; }

        [Required]
        public string naslov { get; set; }
        [Required]
        [Display(Name = "Izdavač")]
        public int izdavacID { get; set; }
        [Required]
        public int broj_stranica { get; set; }
        [Required]
        public int cijena { get; set; }
        [Required]
        public string godina_izdanja { get; set; }

        public List<Izdavac> lstIzdavaci { get; set; }
        public static DataSet ds { get; set; }
        private static string cs = "Data Source =.\\SQLExpress; Initial Catalog = knjiznica; Integrated Security = True;";

        public Knjiga()
        {
            lstIzdavaci = new List<Izdavac>();
            ds = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM izdavac");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Izdavac izdavac = new Izdavac();
                izdavac.izdavacID = int.Parse(row["izdavacID"].ToString());
                izdavac.ime_izdavaca = row["ime_izdavaca"].ToString();
                izdavac.broj_telefona = row["broj_telefona"].ToString();
                izdavac.fax = row["fax"].ToString();
                izdavac.email = row["email"].ToString();
                lstIzdavaci.Add(izdavac);
            }
        }
        public Knjiga(bool isSingle)
        {
            if (isSingle)
            {
                lstIzdavaci = new List<Izdavac>();
                ds = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM izdavac");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Izdavac izdavac = new Izdavac();
                    izdavac.izdavacID = int.Parse(row["izdavacID"].ToString());
                    izdavac.ime_izdavaca = row["ime_izdavaca"].ToString();
                    izdavac.broj_telefona = row["broj_telefona"].ToString();
                    izdavac.fax = row["fax"].ToString();
                    izdavac.email = row["email"].ToString();
                    lstIzdavaci.Add(izdavac);
                }
            }
        }
    }
}