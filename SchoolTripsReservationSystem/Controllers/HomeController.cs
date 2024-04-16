using Microsoft.AspNetCore.Mvc;
using SchoolTripsReservationSystem.Core.Contracts;

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
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            if (statusCode == 404)
            {
                return View("Error404");
            }

            if (statusCode == 500)
            {
                return View("Error500");
            }

            return View();
        }
    }
}
