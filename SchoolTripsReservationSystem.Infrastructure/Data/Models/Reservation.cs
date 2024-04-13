using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolTripsReservationSystem.Infrastructure.Data.Models
{
    [Comment("Reservation for school trip")]
    public class Reservation
    {
        [Key]
        [Comment("Reservation identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Excursion identifier")]
        public int ExcursionId { get; set; }

        public Excursion Excursion { get; set; } = null!;

        [Required]
        [Comment("Date of departure")]
        public DateTime StartingDate { get; set; }

        [Required]
        [Comment("Count of the students")]
        public int StudentCount { get; set; }

        [Comment("Count of the adults")]
        public int EscortAdultCount { get; set; }

        [Required]
        [Comment("Transport identifier")]
        public int TransportId { get; set; }

        public Transport Transport { get; set; } = null!;

        [Required]
        [Comment("School identifier")]
        public int SchoolId { get; set; }

        public School School { get; set; } = null!;

        [Required]
        [Comment("User ID of the group leader - teacher")]
        public string? GroupLeaderId { get; set; }

        [ForeignKey(nameof(GroupLeaderId))]
        public IdentityUser GroupLeader { get; set; } = null!;

        [Required]
        [Comment("Count of the teachers, without group leader")]
        public int TeacherCount { get; set; }
    }
}
