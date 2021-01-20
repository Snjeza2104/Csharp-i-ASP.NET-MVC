namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Narudzbe")]
    public partial class Narudzbe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Narudzbe()
        {
            NarudzbeDetalji = new HashSet<NarudzbeDetalji>();
        }

        public int Id { get; set; }

        public int KorisnikId { get; set; }

        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public DateTime DatumKreiranja { get; set; }

        public DateTime DatumVrijemeDostave { get; set; }

        public bool JeDostavljeno { get; set; }

        public virtual Korisnici Korisnici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NarudzbeDetalji> NarudzbeDetalji { get; set; }
    }
}
