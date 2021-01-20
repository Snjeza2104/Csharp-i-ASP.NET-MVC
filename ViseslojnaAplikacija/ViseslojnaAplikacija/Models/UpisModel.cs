using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViseslojnaAplikacija.Models
{
    public class UpisModel
    {
        public int IdPolaznik { get; set; }
        public int IdTecaj { get; set; }
        public DateTime DatumUpisa { get; set; }
    }
}