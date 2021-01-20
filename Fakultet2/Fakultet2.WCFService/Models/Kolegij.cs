using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Net;
using System.Runtime.Serialization;

namespace Fakultet2.WCFService.Models
{
    [DataContract]
    public class Kolegij
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataMember]
        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }
        [DataMember]
        [Required]
        [StringLength(500)]
        public string Opis { get; set; }
        [DataMember]
        [StringLength(20)]
        public string Ucionica { get; set; }
        [DataMember]
        public DateTime DatumPocetka { get; set; }
    }
}