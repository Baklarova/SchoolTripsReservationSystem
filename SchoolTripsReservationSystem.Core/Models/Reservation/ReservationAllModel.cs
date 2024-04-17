﻿using System.ComponentModel.DataAnnotations;

namespace SchoolTripsReservationSystem.Core.Models.Reservation
{
    public class ReservationAllModel 
    {
		public int Id { get; set; }
		public string Excursion { get; set; } = string.Empty;

		[Display(Name = "Date of departure")]
		public string StartingDate { get; set; } = string.Empty;

		[Display(Name = "Count of the students")]
		public int StudentCount { get; set; }

		[Display(Name = "Count of the adults")]
		public int EscortAdultCount { get; set; }

		public string Transport { get; set; } = string.Empty;

		public string School { get; set; } = string.Empty;

		[Display(Name = "Group Leader Teacher")]
		public string GroupLeaderName { get; set; } = string.Empty;

		[Display(Name = "Count of the teachers")]
		public int TeacherCount { get; set; }

		[Display(Name = "Total Price")]
		public decimal TotalPrice { get; set; }

		public IEnumerable<string> Excursions { get; set; } = null!;

		public IEnumerable<string> Transports { get; set; } = null!;

		public IEnumerable<string> Schools { get; set; } = null!;
		
    }
}