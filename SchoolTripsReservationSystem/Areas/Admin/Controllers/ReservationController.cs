using Microsoft.AspNetCore.Mvc;
using SchoolTripsReservationSystem.Core.Contracts;

namespace SchoolTripsReservationSystem.Areas.Admin.Controllers
{
    public class ReservationController : AdminBaseController
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService _reservationService)
        {
            reservationService = _reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> Approve()
        {

            var model = await reservationService.GetUnApprovedAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int reservationId)
        {
            await reservationService.ApproveReservationAsync(reservationId);
            return RedirectToAction(nameof(Approve));
        }
    }
}
