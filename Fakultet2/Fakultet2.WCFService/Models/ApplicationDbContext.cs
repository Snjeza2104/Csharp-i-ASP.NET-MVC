using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Net;

namespace Fakultet2.WCFService.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            :base("FakultetBaza")
        {

        }
        public virtual DbSet<Kolegij> Kolegiji { get; set; }
    }
}