using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SchoolTripsReservationSystem.Infrastructure.Constants.DataConstants;

namespace SchoolTripsReservationSystem.Infrastructure.Data.Models
{
    [Index(nameof(Eik), IsUnique = true)]
    [Comment("School data")]
    public class School
    {
        [Key]
        [Comment("School identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        [Comment("School official name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(SchoolAddressMaxLenght)]
        [Comment("School address")]
        public string Address { get; set; } = string.Empty;

        [Required]

        [MaxLength(SchoolEikMaxLenght)]
        [Comment("School identification number")]
        public string Eik { get; set; } = string.Empty;

        [Required]
        [Comment("School director name/MOL")]
        public string Mol { get; set; } = string.Empty;

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
