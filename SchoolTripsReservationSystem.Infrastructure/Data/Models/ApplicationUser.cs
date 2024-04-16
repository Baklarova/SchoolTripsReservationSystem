using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static SchoolTripsReservationSystem.Infrastructure.Constants.DataConstants;

namespace SchoolTripsReservationSystem.Infrastructure.Data.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		[MaxLength(UserFirstNameMaxLenght)]
		[PersonalData]
        public string FirstName { get; set; } = string.Empty;

		[Required]
		[MaxLength(UserLastNameMaxLenght)]
		[PersonalData]
		public string LastName { get; set; } = string.Empty;

    }
}
