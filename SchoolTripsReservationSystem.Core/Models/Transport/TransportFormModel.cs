using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SchoolTripsReservationSystem.Core.Constants.MessageConstants;
using static SchoolTripsReservationSystem.Infrastructure.Constants.DataConstants;

namespace SchoolTripsReservationSystem.Core.Models.Transport
{
    public class TransportFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = LenghtMessage)]
        [Display(Name = "Transport name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(TransportCapasityMinNumber, TransportCapasityMaxNumber, ErrorMessage = TransportCapasityMassage)]
        [Display(Name = "Transport Capacity")]
        public int TransportCapacity { get; set; }
    }
}
