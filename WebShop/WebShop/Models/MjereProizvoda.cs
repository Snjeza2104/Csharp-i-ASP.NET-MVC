namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MjereProizvoda")]
    public partial class MjereProizvoda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MjereProizvoda()
        {
            Proizvodi = new HashSet<Proizvodi>();
        }

        public short Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Naziv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proizvodi> Proizvodi { get; set; }
    }
}
