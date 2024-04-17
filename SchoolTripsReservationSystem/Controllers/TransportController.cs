using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Core.Models.School;
using SchoolTripsReservationSystem.Core.Models.Transport;
using SchoolTripsReservationSystem.Core.Services;

namespace SchoolTripsReservationSystem.Controllers
{
    [Authorize]
    public class TransportController : Controller
    {
        private readonly ITransportService transportService;

        public TransportController(ITransportService _transportService)
        {
            transportService = _transportService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new TransportFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TransportFormModel model)
        {


            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await transportService.CreateAsync(model.Name, model.TransportCapacity); ;


            return RedirectToAction(nameof(ExcursionController.All), "Excursion");
        }
    }
}
