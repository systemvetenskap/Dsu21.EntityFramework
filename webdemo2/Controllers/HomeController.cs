using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webdemo2.Models;
using webdemo2.Repositories;

namespace webdemo2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbOperations db;
        private readonly ICarOperations carDb;

        public HomeController(IDbOperations dbOperations, ICarOperations carOperations, ILogger<HomeController> logger)
        {
            db = dbOperations;
            _logger = logger;
            carDb = carOperations;
        }

        public async Task<IActionResult> Index()
        {

            //var car = carDb.AddCar("Opel", "Ascona");
            var person = await carDb.AddPersonAsync("Erik", "Berg");
            var car = carDb.GetCar(1);
            //carDb.AddCarRegistry(car);
            return View();
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
    }
}
