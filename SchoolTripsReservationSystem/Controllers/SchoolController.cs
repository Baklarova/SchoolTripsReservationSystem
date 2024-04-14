using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolTripsReservationSystem.Core.Models.Excursion;
using SchoolTripsReservationSystem.Core.Models.School;

namespace SchoolTripsReservationSystem.Controllers
{
    [Authorize]
    public class SchoolController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SchoolFormModel model)
        {

            return RedirectToAction(nameof(ExcursionController.All), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new SchoolFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SchoolFormModel model)
        {

            return RedirectToAction(nameof(ExcursionController.All), new { id = 1 });
        }
    }
}
