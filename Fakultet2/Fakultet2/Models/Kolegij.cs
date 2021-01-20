using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fakultet2.Models
{
    public class Kolegij
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }
        [Required]
        [StringLength(500)]
        public string Opis { get; set; }
        [StringLength(20)]
        public string Ucionica { get; set; }
        public DateTime DatumPocetka { get; set; }
    }
}