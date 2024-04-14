using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolTripsReservationSystem.Core.Models.Transport;

namespace SchoolTripsReservationSystem.Controllers
{
    [Authorize]
    public class TransportController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(TransportFormModel model)
        {

            return RedirectToAction(nameof(ExcursionController.All), new { id = 1 });
        }
    }
}
