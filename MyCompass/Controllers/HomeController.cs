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
using Tweetinvi;

namespace MyCompass.Controllers
{
    
    [Authorize]
    public class HomeController : Controller
    {
        private readonly MyCompassContext _context;
        private readonly ILogger<HomeController> _logger;

        public string MyString { get; set; }
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

        public async Task<IActionResult> AboutUs()
        {
            string userDetalis = await twiter();
            return View("AboutUs",userDetalis);
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
 
        public async Task<string> twiter()
        {
            var userClient = new TwitterClient("5XMOijnEtAjiGRPgiKrZLAQRv", "CtCNBHB4ypLmkkeOSlbGTFt1slQHnT3hI46T9emHn0skA1Elui", "1459160998871457792-dDgIRs5r8ehEO8fbAehBhLADk2YHZS", "VpsigGR2sTaejvsmXn8arXZnlpw8dbVJzvrYIyj8eNVfE");
            var user = await userClient.Users.GetAuthenticatedUserAsync();
            string userDetalis = user + " number of twitter Followers " + user.FollowersCount;
            return userDetalis;
        }
    }
}
