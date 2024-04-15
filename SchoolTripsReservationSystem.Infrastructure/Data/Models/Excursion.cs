using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SchoolTripsReservationSystem.Infrastructure.Constants.DataConstants;

namespace SchoolTripsReservationSystem.Infrastructure.Data.Models
{
    [Comment("School excursion")]
    public class Excursion
    {
        [Key]
        [Comment("Excursion identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        [Comment("Excursion name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Excursion duration in days")]
        public int Duration { get; set; } 

        [MaxLength(ExcursionDescriptionMaxLenght)]
        [Comment("Excursion Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Excursion price per student")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerStudent { get; set; }

        [Required]
        [Comment("Excursion price per adult-escort")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerAdult { get; set; }

        [Required]
        [Comment("Region identifier")]
        public int RegionId { get; set; }

        public Region Region { get; set; } = null!;

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
