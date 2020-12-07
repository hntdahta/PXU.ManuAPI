using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PXU.ManuAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PXU.ManuAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //List<Category> categories = new List<Category>();
            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Helper.Helper.domainUrl}api/category/gets");
            //httpWebRequest.Method = "GET";
            //var response = httpWebRequest.GetResponse();
            //{
            //    string responseData;
            //    Stream responseStream = response.GetResponseStream();
            //    try
            //    {
            //        using (StreamReader sr = new StreamReader(responseStream))
            //        {
            //            responseData = sr.ReadToEnd();
            //        }
            //    }
            //    finally
            //    {
            //        ((IDisposable)responseStream).Dispose();
            //    }
            //    categories = JsonConvert.DeserializeObject<List<Category>>(responseData);
            //}
            List<Manufactory> categories = new List<Manufactory>();
            categories = Helper.ApiHelper<List<Manufactory>>.HttpGetAsync("api/manafactory/gets");
            return View(categories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Manufactory model)
        {
            if (ModelState.IsValid)
            {
                var result = new CreateManufactoryResult();
                result = Helper.ApiHelper<CreateManufactoryResult>.HttpPostAsync("api/manafactory/create", "POST", model);
                if (result.ManufactoryId > 0)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
            return View(model);
        }
    }
}
