using System.ComponentModel.DataAnnotations;
using static SchoolTripsReservationSystem.Core.Constants.MessageConstants;
using static SchoolTripsReservationSystem.Infrastructure.Constants.DataConstants;

namespace SchoolTripsReservationSystem.Core.Models.Excursion
{
    public class ExcursionServiceModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = LenghtMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(ExcursionDurationMinNumber, ExcursionDurationMaxNumber, ErrorMessage = DurationMassage)]
        public int Duration { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), ExcursionPriceMinAmount, ExcursionPriceMaxAmount, ConvertValueInInvariantCulture = true, ErrorMessage = PriceMassage)]
        [Display(Name = "Price per studrnt")]
        public decimal PricePerStudent { get; set; }

    }
}