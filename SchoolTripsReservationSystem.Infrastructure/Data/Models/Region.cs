using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SchoolTripsReservationSystem.Infrastructure.Constants.DataConstants;

namespace SchoolTripsReservationSystem.Infrastructure.Data.Models
{
    [Comment("Geographic region")]
    public class Region
    {
        [Key]
        [Comment("Region identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = string.Empty;

        public List<Excursion> Excursions { get; set;} = new List<Excursion>();
    }
}
