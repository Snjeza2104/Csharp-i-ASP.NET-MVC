using WebAPIFakultet.Models;
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

namespace WebAPIFakultet.Controllers
{
    public class HomeController : Controller
    {
        private KolegijiRESTService service = new KolegijiRESTService();
        //GET: api/proizvodi
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View("Index", await service.DohvatiProizvodeAsync());
        }

       //GET: api/proizvodi/id
       [HttpGet]
       [ResponseType(typeof(Kolegij))]
       public async Task<ActionResult> Details(int id)
        {
            return View("Details", await service.DohvatiProizvodByIdAsync(id));
        }

        public class KolegijiRESTService
        {
            readonly string uri = "https://localhost:44313/api/kolegijs/";
            public async Task<List<Kolegij>> DohvatiProizvodeAsync()
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    return JsonConvert.DeserializeObject<List<Kolegij>>(
                        await httpClient.GetStringAsync(uri));
                }
            }
            public async Task<Kolegij> DohvatiProizvodByIdAsync(int id)
            {
                using(HttpClient httpClient=new HttpClient())
                {
                    return JsonConvert.DeserializeObject<Kolegij>(
                        await httpClient.GetStringAsync(uri + id));
                }
            }
        }
    }
}