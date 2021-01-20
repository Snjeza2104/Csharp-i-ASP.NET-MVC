namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KategorijeProizvodi")]
    public partial class KategorijeProizvodi
    {
        public int Id { get; set; }

        public int ProizvodId { get; set; }

        public int KategorijaId { get; set; }

        public virtual Kategorije Kategorije { get; set; }

        public virtual Proizvodi Proizvodi { get; set; }
    }
}
