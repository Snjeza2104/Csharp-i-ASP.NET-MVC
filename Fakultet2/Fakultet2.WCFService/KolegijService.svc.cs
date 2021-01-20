using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Fakultet2.WCFService.Models;

namespace Fakultet2.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "KolegijService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select KolegijService.svc or KolegijService.svc.cs at the Solution Explorer and start debugging.
    public class KolegijService : IKolegijService
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        public Kolegij DohvatiKolegij(int id)
        {
            Kolegij odabraniKolegij = (from k in _db.Kolegiji where k.Id == id select k).SingleOrDefault();
            return odabraniKolegij;
        }

        public List<Kolegij> DohvatiKolegije()
        {
            var aktivniKolegiji = from k in _db.Kolegiji where k.DatumPocetka >= DateTime.Now select k;
            return aktivniKolegiji.ToList();
        }
    }
}
