using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace knjiznica.Models
{
    public class Izdavac
    {
		public int izdavacID { get; set; }
		public string ime_izdavaca { get; set; }
		public string broj_telefona { get; set; }
		public string fax { get; set; }
		public string email { get; set; }
    }
}
