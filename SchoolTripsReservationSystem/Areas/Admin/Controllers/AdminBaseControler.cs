using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SchoolTripsReservationSystem.Core.Constants.RoleConstants;

namespace SchoolTripsReservationSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseControler : Controller
    {
        
    }
}
