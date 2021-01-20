using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace knjiznica.Models
{
    public class Posudjivac
    {
        public int posudjivacID { get; set; }
        public string prezime { get; set; }
        public string ime { get; set; }
        public string mobitel { get; set; }
        public string email { get; set; }
   
    }
}