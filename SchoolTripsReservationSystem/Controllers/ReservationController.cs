using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolTripsReservationSystem.Core.Models.Reservation;

namespace SchoolTripsReservationSystem.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        public async Task<IActionResult> My()
        {
            var model = new MyReservationModel();
            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var model = new ReservationDetailsModel();
            return View(model);
        }

        public async Task<IActionResult> Make(int id)
        {
            return RedirectToAction(nameof(My));
        }
    }
}
