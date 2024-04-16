using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Core.Models.Excursion;
using static SchoolTripsReservationSystem.Core.Constants.MessageConstants;

namespace SchoolTripsReservationSystem.Controllers
{
    [Authorize]
    public class ExcursionController : Controller
    {
        private readonly IExcursionService excursionService;

        public ExcursionController(IExcursionService _excursionService)
        {
            excursionService = _excursionService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]AllExcursionsModel query)
        {
            var model = await excursionService.AllAsync(
                query.Region,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.ExcursionsPerPage);

            query.TotalExcursionsCount = model.TotalExcursionCount;
            query.Excursions = model.Excursions;
            query.Regions = await excursionService.AllRegionsNamesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await excursionService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
            var model = await excursionService.ExcursionDetailsByIdAsync(id);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ExcursionFormModel()
            {
                Regions = await excursionService.AllRegionsAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExcursionFormModel model)
        {
            if (await excursionService.RegionExistsAsync(model.RegionId) == false)
            {
                ModelState.AddModelError(nameof(model.RegionId), RegionNotExists);
            }

            if (ModelState.IsValid == false)
            {
                model.Regions = await excursionService.AllRegionsAsync();

                return View(model);
            }

            int newExcursionId = await excursionService.CreateAsync(model);

            return RedirectToAction(nameof(Details), new { id = newExcursionId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await excursionService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await excursionService.GetExcursionFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ExcursionFormModel model)
        {
            if (await excursionService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await excursionService.RegionExistsAsync(model.RegionId) == false)
            {
                ModelState.AddModelError(nameof(model.RegionId), RegionNotExists);
            }

            if (ModelState.IsValid == false)
            {
                model.Regions = await excursionService.AllRegionsAsync();
                return View(model);
            }

            await excursionService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await excursionService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var excursion = await excursionService.ExcursionDetailsByIdAsync(id);

            var model = new ExcursionDetailsModel()
            { 
                Id = excursion.Id,
                Name = excursion.Name,
                Duration = excursion.Duration,
                Description = excursion.Description
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ExcursionDetailsModel model)
        {

            if (await excursionService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            await excursionService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
