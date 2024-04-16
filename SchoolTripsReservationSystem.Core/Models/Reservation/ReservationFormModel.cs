using SchoolTripsReservationSystem.Core.Models.Excursion;
using System.ComponentModel.DataAnnotations;
using static SchoolTripsReservationSystem.Core.Constants.MessageConstants;
using static SchoolTripsReservationSystem.Infrastructure.Constants.DataConstants;

namespace SchoolTripsReservationSystem.Core.Models.Reservation
{
    public class ReservationFormModel
    {
        [Display(Name = "Excursion")]
        public int ExcursionId { get; set; }
        public IEnumerable<ReservationExcursionServiceModel> Excursions { get; set; } = new List<ReservationExcursionServiceModel>();

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Date of departure")]
        public string StartingDate { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(StudentsMixPax, StudentsMaxPax, ErrorMessage = StudentsMassage)]
        [Display(Name = "Count of the students")]
        public int StudentCount { get; set; }

        [Range(AdultsMixPax, AdultsMaxPax, ErrorMessage = AdultMassage)]
        [Display(Name = "Count of the adults")]
        public int EscortAdultCount { get; set; }

        [Display(Name = "Transport")]
        public int TransportId { get; set; }
        public IEnumerable<ReservationTransportServiceModel> Transports { get; set; } = new List<ReservationTransportServiceModel>();

        [Display(Name = "School")]
        public int SchoolId { get; set; }
        
        public IEnumerable<ReservationSchoolServiceModel> Schools { get; set; } = new List<ReservationSchoolServiceModel>();

        [Range(AdultsMixPax, AdultsMaxPax, ErrorMessage = TeacherMassage)]
        [Display(Name = "Count of the teachers")]
        public int TeacherCount { get; set; }

    }
}
