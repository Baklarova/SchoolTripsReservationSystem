using Microsoft.AspNetCore.Mvc;

namespace SchoolTripsReservationSystem.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseControler
    {
        public IActionResult DashBoard()
        {
            return View();
        }
        public async Task<IActionResult> ForReview()
        {
            return View();
        }
        
    }
}
