using System.ComponentModel.DataAnnotations;
using static SchoolTripsReservationSystem.Core.Constants.MessageConstants;
using static SchoolTripsReservationSystem.Infrastructure.Constants.DataConstants;

namespace SchoolTripsReservationSystem.Core.Models.School
{
    public class SchoolFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = LenghtMessage)]
        [Display(Name = "School name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SchoolAddressMaxLenght, MinimumLength = SchoolAddressMinLenght, ErrorMessage = LenghtMessage)]
        [Display(Name = "School address")]
        public string Address { get; set; } = null!;


        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SchoolEikMaxLenght, MinimumLength = SchoolEikMinLenght, ErrorMessage = EikLenghtMessage)]
        [Display(Name = "School EIK")]
        public string Eik { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = LenghtMessage)]
        [Display(Name = "School director name/MOL")]
        public string Mol { get; set; } = null!;
    }
}
