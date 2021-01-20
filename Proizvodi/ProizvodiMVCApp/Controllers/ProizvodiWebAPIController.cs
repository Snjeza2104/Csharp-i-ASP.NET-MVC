using ProizvodiMVCApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace ProizvodiMVCApp.Controllers
{
    public class ProizvodiWebAPIController : Controller
    {
        private ProizvodiRESTService service = new ProizvodiRESTService();

        //GET: api/proizvodi
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View("Index", await service.DohvatiProizvodeAsync());
        }

        //GET: api/proizvodi/id
        [HttpGet]
        [ResponseType(typeof(Proizvod))]
        public async Task<ActionResult> Details(int id)
        {
            return View("Details", await service.DohvatiProizvodByIdAsync(id));
        }

        public class ProizvodiRESTService
        {
            readonly string uri = "https://localhost:44389/api/proizvodi/";
            public async Task<List<Proizvod>> DohvatiProizvodeAsync()
            {
                using(HttpClient httpClient=new HttpClient())
                {
                    return JsonConvert.DeserializeObject<List<Proizvod>>(await httpClient.GetStringAsync(uri));
                }

            }

            public async Task<Proizvod> DohvatiProizvodByIdAsync(int id)
            {
                using(HttpClient httpClient=new HttpClient())
                {
                    return JsonConvert.DeserializeObject<Proizvod>(await httpClient.GetStringAsync(uri + id));
                }
            }
        }
    }
}