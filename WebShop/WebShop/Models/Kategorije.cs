namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kategorije")]
    public partial class Kategorije
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kategorije()
        {
            KategorijeProizvodi = new HashSet<KategorijeProizvodi>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        [StringLength(500)]
        public string Opis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KategorijeProizvodi> KategorijeProizvodi { get; set; }
    }
}
