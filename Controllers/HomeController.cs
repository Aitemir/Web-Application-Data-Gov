using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDataGov.Models;
using static WebApplicationDataGov.Models.EF_Models;
using WebApplicationDataGov.DataAccess;
using Newtonsoft.Json;
using System.Net.Http;

namespace WebApplicationDataGov.Controllers
{

    public class HomeController : Controller
    {

        public ApplicationDbContext dbContext;

        string BASE_URL = "https://api.data.gov/ed/collegescorecard/v1/";
        HttpClient httpClient;

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
            System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Rootobject GetSchools()
        {
            string DATA_GOV_API_PATH = BASE_URL + "schools?school.degrees_awarded.predominant=2,3&fields=id,school.name,2017.student.size&api_key=rdesCWBgxKPHVZyvaC4cwzT94Gtt3zc637y58Pcj";
            string rootobjectData = "";
            Rootobject rootobject = null;

            httpClient.BaseAddress = new Uri(DATA_GOV_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(DATA_GOV_API_PATH).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                rootobjectData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            if (!rootobjectData.Equals(""))
            {
                rootobject = JsonConvert.DeserializeObject<Rootobject>(rootobjectData);
            }

            return rootobject;
        }

        public IActionResult Index()
        {
            ViewBag.dbSuccessComp = 0;
            Rootobject rootobject = GetSchools();

            TempData["Schools"] = JsonConvert.SerializeObject(rootobject);

            return View(rootobject);
        }

        public IActionResult Schools()
        {
            ViewBag.dbSuccessComp = 0;
            Rootobject rootobject = GetSchools();

            TempData["Schools"] = JsonConvert.SerializeObject(rootobject);

            return View(rootobject);
        }

   
        public IActionResult PopulateSchools()
        {

            Rootobject rootobject = GetSchools();

            TempData["Schools"] = JsonConvert.SerializeObject(rootobject);

            rootobject = JsonConvert.DeserializeObject<Rootobject>(TempData["Schools"].ToString());

            foreach (School school in rootobject.results)
            {
                if (dbContext.Schools.Where(c => c.id.Equals(school.id)).Count() == 0)
                {
                    dbContext.Schools.Add(school);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index", rootobject);
        }

        // second view: 

        public Rootobject GetFloridaSchools()
        {
            string DATA_GOV_API_PATH = BASE_URL + "schools.json?id__not=20627902&school.name=Florida&fields=id,school.name,2017.student.size&api_key=rdesCWBgxKPHVZyvaC4cwzT94Gtt3zc637y58Pcj";
            string rootobjectData = "";
            Rootobject rootobject = null;

            httpClient.BaseAddress = new Uri(DATA_GOV_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(DATA_GOV_API_PATH).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                rootobjectData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            if (!rootobjectData.Equals(""))
            {
                rootobject = JsonConvert.DeserializeObject<Rootobject>(rootobjectData);
                rootobject.results = rootobject.results.GetRange(0,10);
            }

            return rootobject;
        }

        public IActionResult FloridaSchools()
        {
            ViewBag.dbSuccessComp = 0;
            Rootobject rootobject = GetFloridaSchools();

            TempData["FloridaSchools"] = JsonConvert.SerializeObject(rootobject);

            return View(rootobject);
        }

        public IActionResult StateSchoolsFL()
        {
            ViewBag.dbSuccessComp = 0;
            Rootobject rootobject = GetFloridaSchools();

            TempData["FloridaSchools"] = JsonConvert.SerializeObject(rootobject);

            return View(rootobject);
        }


        public IActionResult PopulateFloridaSchools()
        {
            Rootobject rootobject = JsonConvert.DeserializeObject<Rootobject>(TempData["FloridaSchools"].ToString());

            foreach (School school in rootobject.results)
            {
                if (dbContext.Schools.Where(c => c.id.Equals(school.id)).Count() == 0)
                {
                    dbContext.Schools.Add(school);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("FloridaSchools", rootobject);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
