using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolTripsReservationSystem.Core.Models.Excursion;

namespace SchoolTripsReservationSystem.Controllers
{
    [Authorize]
    public class ExcursionController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllExcursionsModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new ExcursionDetailsModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExcursionFormModel model)
        {

            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new ExcursionFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ExcursionFormModel model)
        {

            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new ExcursionDetailsModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ExcursionDetailsModel model)
        {

            return RedirectToAction(nameof(All));
        }
    }
}
