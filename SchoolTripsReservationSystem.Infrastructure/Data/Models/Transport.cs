using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SchoolTripsReservationSystem.Infrastructure.Constants.DataConstants;

namespace SchoolTripsReservationSystem.Infrastructure.Data.Models
{
    [Comment("Transport for excursion")]
    public class Transport
    {
        [Key]
        [Comment("Transport identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Transport name")]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Мaximum number of seats in the vehicle")]
        public int TransportCapacity { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
