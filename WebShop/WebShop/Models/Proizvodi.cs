namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proizvodi")]
    public partial class Proizvodi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proizvodi()
        {
            KategorijeProizvodi = new HashSet<KategorijeProizvodi>();
            NarudzbeDetalji = new HashSet<NarudzbeDetalji>();
        }

        public int Id { get; set; }

        public short MjeraProizvodaId { get; set; }

        public DateTime VrijemeKreiranja { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        public decimal Cijena { get; set; }

        public bool Dostupan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KategorijeProizvodi> KategorijeProizvodi { get; set; }

        public virtual MjereProizvoda MjereProizvoda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NarudzbeDetalji> NarudzbeDetalji { get; set; }
    }
}
