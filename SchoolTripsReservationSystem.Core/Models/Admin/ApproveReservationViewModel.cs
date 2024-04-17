using System.ComponentModel.DataAnnotations;

namespace SchoolTripsReservationSystem.Core.Models.Admin
{
    public class ApproveReservationViewModel
    {
        public int ReservationId { get; set; }

        [Display(Name = "Excursion Name")]
        public string ExcursionName { get; set; } = string.Empty;

        [Display(Name = "Date of departure")]
        public string StartingDate { get; set; } = string.Empty;

        [Display(Name = "Count of the students")]
        public int StudentCount { get; set; }

    }
}
