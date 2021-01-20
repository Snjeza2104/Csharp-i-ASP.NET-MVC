using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProizvodiMVCApp.Models
{
    public class Proizvod
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Kategorija { get; set; }
        public decimal Cijena { get; set; }
    }
}