using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Core.Models.School;
using static SchoolTripsReservationSystem.Core.Constants.MessageConstants;

namespace SchoolTripsReservationSystem.Controllers
{
    [Authorize]
    public class SchoolController : Controller
    {
        private readonly ISchoolService schoolService;

        public SchoolController(ISchoolService _schoolService)
        {
            schoolService = _schoolService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SchoolFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SchoolFormModel model)
        {
            if (await schoolService.SchoolWithEikExistsAsync(model.Eik))
            {
                ModelState.AddModelError(nameof(model.Eik), EikExists);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await schoolService.CreateAsync(model.Name, model.Address, model.Eik, model.Mol);
            

            return RedirectToAction(nameof(ExcursionController.All), "Excursion");
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

            return RedirectToAction(nameof(ExcursionController.All), "Excursion");
        }
    }
}
