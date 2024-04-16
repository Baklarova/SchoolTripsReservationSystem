using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Core.Models.Reservation;
using SchoolTripsReservationSystem.Extensions;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;
using System.Globalization;
using static SchoolTripsReservationSystem.Core.Constants.MessageConstants;
using static SchoolTripsReservationSystem.Infrastructure.Constants.DataConstants;

namespace SchoolTripsReservationSystem.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService _reservationService)
        {
            reservationService = _reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> My()
        {
            var userId = User.Id();
            IEnumerable<ReservationServiceModel> model;
            model = await reservationService.AllReservaionByUserId(userId);           

            return View(model);
        }

        
        public async Task<IActionResult> Detail(int id)
        {
            var model = new ReservationDetailsModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Make()
        {
            var model = new ReservationFormModel()
            {
                Excursions = await reservationService.AllExcursionsAsync(),
                Transports = await reservationService.AllTransportsAsync(),
                Schools = await reservationService.AllSchoolsAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Make(ReservationFormModel model)
        {
            DateTime departurDate = DateTime.Now;

            if (!DateTime.TryParseExact(model.StartingDate, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out departurDate))
            {
                ModelState.AddModelError(nameof(model.StartingDate), "Invalid date! Format must be: dd.MM.yyyy HH:mm:ss");
            }

            if (await reservationService.ExcursionExistsAsync(model.ExcursionId) == false)
            {
                ModelState.AddModelError(nameof(model.ExcursionId), "Excursion does not exist");
            }

            if (await reservationService.TransportExistsAsync(model.TransportId) == false)
            {
                ModelState.AddModelError(nameof(model.TransportId), "Transport does not exist");
            }

            if (await reservationService.SchoolExistsAsync(model.SchoolId) == false)
            {
                ModelState.AddModelError(nameof(model.SchoolId), "School does not exist");
            }

            if (ModelState.IsValid == false)
            {
                model.Excursions = await reservationService.AllExcursionsAsync();
                model.Transports = await reservationService.AllTransportsAsync();
                model.Schools = await reservationService.AllSchoolsAsync();
            }

            string userId = User.Id();

            int newReservationId = await reservationService.CreateAsync(model, userId);

            return RedirectToAction(nameof(My), new { id = newReservationId});
        }
    }
}
