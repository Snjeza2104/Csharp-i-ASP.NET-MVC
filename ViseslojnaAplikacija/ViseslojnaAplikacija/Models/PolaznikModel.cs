using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ViseslojnaAplikacija.Models
{
    public class PolaznikModel
    {
        public int IdPolaznik { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name ="Grad")]
        public int IdGrad { get; set; }
        public List<GradModelcs> lstGradovi { get; set; }
        public static DataSet ds { get; set; }
        private static string cs= "Data Source =.\\SQLExpress; Initial Catalog = dbAlgebra10; Integrated Security = True;";

        public PolaznikModel()
        {
            lstGradovi = new List<GradModelcs>();
            ds = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM tblGradovi");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                GradModelcs grad = new GradModelcs();
                grad.IdGrad = int.Parse(row["IdGrad"].ToString());
                grad.Naziv = row["Naziv"].ToString();
                lstGradovi.Add(grad);
            }
        }
        public PolaznikModel (bool isSingle)
        {
            if (isSingle)
            {
                lstGradovi = new List<GradModelcs>();
                ds = SqlHelper.ExecuteDataset(cs, CommandType.Text, "SELECT * FROM tblGradovi");
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    GradModelcs grad = new GradModelcs();
                    grad.IdGrad = int.Parse(row["IdGrad"].ToString());
                    grad.Naziv = row["Naziv"].ToString();
                    lstGradovi.Add(grad);
                }
            }
        }
    }
}