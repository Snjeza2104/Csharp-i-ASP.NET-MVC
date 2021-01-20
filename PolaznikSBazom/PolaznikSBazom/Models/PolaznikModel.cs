using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolaznikSBazom.Models
{
    public class PolaznikModel
    {
        public int IdPolaznik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        //public DateTime DatumRodjenja { get; set; }
    }
}