using Microsoft.AspNetCore.Mvc;

namespace SchoolTripsReservationSystem.Areas.Admin.Controllers
{
    public class AdminHomeController : AdminBaseControler
    {
        public IActionResult DashBoard()
        {
            return View();
        }

        
    }
}
