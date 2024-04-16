using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Core.Models.Region;
using System.ComponentModel.DataAnnotations;
using static SchoolTripsReservationSystem.Core.Constants.MessageConstants;
using static SchoolTripsReservationSystem.Infrastructure.Constants.DataConstants;


namespace SchoolTripsReservationSystem.Core.Models.Excursion
{
    public class ExcursionFormModel : IExcursionModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = LenghtMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(ExcursionDurationMinNumber, ExcursionDurationMaxNumber, ErrorMessage = DurationMassage)]
        public int Duration { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ExcursionDescriptionMaxLenght, MinimumLength = ExcursionDescriptionMinLenght, ErrorMessage = LenghtMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof (decimal), ExcursionPriceMinAmount, ExcursionPriceMaxAmount, ConvertValueInInvariantCulture = true, ErrorMessage = PriceMassage)]
        [Display(Name = "Price per student")]
        public decimal PricePerStudent { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), ExcursionPriceMinAmount, ExcursionPriceMaxAmount, ConvertValueInInvariantCulture = true, ErrorMessage = PriceMassage)]
        [Display(Name = "Price per adult")]
        public decimal PricePerAdult { get; set; }

        [Display(Name = "Region")]
        public int RegionId { get; set; }

        public IEnumerable<ExcursionRegionServiseModel> Regions { get; set; } = new List<ExcursionRegionServiseModel>();

    }
}
