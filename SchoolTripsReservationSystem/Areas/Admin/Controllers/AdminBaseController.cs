using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SchoolTripsReservationSystem.Core.Constants.AdministratorConstants;

namespace SchoolTripsReservationSystem.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
        
    }
}
