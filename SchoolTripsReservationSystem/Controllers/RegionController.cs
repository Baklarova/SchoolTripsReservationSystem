using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolTripsReservationSystem.Core.Models.Region;

namespace SchoolTripsReservationSystem.Controllers
{
    [Authorize]
    public class RegionController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegionFormModel model)
        {

            return RedirectToAction(nameof(ExcursionController.All), new { id = 1 });
        }
    }
}
