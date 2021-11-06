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

        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> TripCategoriesByTripEvent()
        {
            // var tripCategories = await _context.TripCategoriesModel.ToListAsync();
            // var tripEvents = await _context.TripEventModel.ToListAsync();
            var category = await _context.TripCategoriesModel.Include(c => c.TripEvents).ToListAsync();
            return View(category);
        }
    }
}
