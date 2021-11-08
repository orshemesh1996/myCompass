using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyCompass.Data;
using MyCompass.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyCompass.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly MyCompassContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyCompassContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var places = _context.PlacesModel.Include(c => c.TripEvents).Include(i => i.PlaceImage);
            return View(await places.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Statistics()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public String TripCategoriesPieChart()
        {
            var categories = _context.TripCategoriesModel.Include(c => c.TripEvents).ToList();
            String result = JsonConvert.SerializeObject(categories, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return result;
        }

        public String PlacesPieChart()
        {
            var places = _context.PlacesModel.Include(c => c.TripEvents).ToList();
            String result = JsonConvert.SerializeObject(places, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return result;
        }
    }
}
