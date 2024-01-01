using FlightApp.Data;
using FlightApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Configuration;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;

namespace FlightApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IConfiguration _configuration, ILogger<HomeController> logger)
        {
            _logger = logger;
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer(_configuration.GetConnectionString("FlightApp"));
            _context = new ApplicationDbContext(optionBuilder.Options);
        }

        public IActionResult Index()
        {
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

        [HttpGet]
        public IActionResult UcusSorgusu(string Departure, string Destination, DateTime? departuredate)
        {
            var sonuc1 = _context.Flights
           .Where(x =>
            EF.Functions.Like(x.FlightDeparture, Departure) &&
            EF.Functions.Like(x.FlightDestination, Destination) &&
            (!departuredate.HasValue || x.FlightDepartureDate.Date == departuredate.Value.Date))
            .ToList();      

            return View("Sonuc", sonuc1);
        }


        public IActionResult Onay()
        {
            return View(); 
        }
    }
}