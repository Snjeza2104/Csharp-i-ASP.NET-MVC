using Proizvodi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proizvodi.Controllers
{
    public class ProizvodiController : ApiController
    {
        Proizvod[] proizvodi = new Proizvod[]
        {
            new Proizvod{Id=1, Naziv="Tomato Soup", Kategorija="Gloceries", Cijena=1  },
            new Proizvod{Id=2, Naziv="Yo-yo", Kategorija="Toys", Cijena=3.75M},
            new Proizvod{Id=3, Naziv="Hammer", Kategorija="Hardware", Cijena=16.99M}
        };

        [HttpGet]
        public IEnumerable<Proizvod> DohvatiSveProizvode()
        {
            return proizvodi;
        }

        [HttpGet]
        public IHttpActionResult DohvatiProizvod(int id)
        {
            var proizvod = proizvodi.FirstOrDefault((p) => p.Id == id);
            if (proizvod == null)
            {
                return NotFound();
            }
            return Ok(proizvod);
        }
    }
}
