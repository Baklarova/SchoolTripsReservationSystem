using System.ComponentModel.DataAnnotations;
using static SchoolTripsReservationSystem.Core.Constants.MessageConstants;
using static SchoolTripsReservationSystem.Infrastructure.Constants.DataConstants;

namespace SchoolTripsReservationSystem.Core.Models.Excursion
{
    public class ExcursionDetailsServiceModel : ExcursionServiceModel
    {
       
        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), ExcursionPriceMinAmount, ExcursionPriceMaxAmount, ConvertValueInInvariantCulture = true, ErrorMessage = PriceMassage)]
        [Display(Name = "Price per adult")]
        public decimal PricePerAdult { get; set; } 

        public string Region { get; set; } = string.Empty;
    }
}
