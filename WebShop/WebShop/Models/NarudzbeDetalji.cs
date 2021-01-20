namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NarudzbeDetalji")]
    public partial class NarudzbeDetalji
    {
        public int Id { get; set; }

        public int? NarudzbaId { get; set; }

        public int? ProizvodId { get; set; }

        public decimal Kolicina { get; set; }

        public decimal JedCijena { get; set; }

        public virtual Narudzbe Narudzbe { get; set; }

        public virtual Proizvodi Proizvodi { get; set; }
    }
}
