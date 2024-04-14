using Microsoft.AspNetCore.Mvc;
using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Core.Models.Home;
using SchoolTripsReservationSystem.Models;
using System.Diagnostics;

namespace SchoolTripsReservationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IExcursionService excursionService;

        public HomeController(
            ILogger<HomeController> logger,
            IExcursionService _excursionService)
        {
            _logger = logger;
            excursionService = _excursionService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await excursionService.OurNewOffersAsync();
            return View(model);
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
