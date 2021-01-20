using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadSaGreskama.Models
{
    public class Kalkulator
    {
        public decimal PrviBroj { get; set; }
        public decimal DrugiBroj { get; set; }
        public decimal Rezultat { get; set; }

        public void Dijeli()
        {
            Rezultat = this.PrviBroj / this.DrugiBroj;
        }

        public void Zbroji()
        {
            Rezultat = this.PrviBroj + this.DrugiBroj;
        }
    }
}