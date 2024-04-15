using SchoolTripsReservationSystem.Core.Enumetations;
using System.ComponentModel.DataAnnotations;

namespace SchoolTripsReservationSystem.Core.Models.Excursion
{
    public class AllExcursionsModel
    {
        public int ExcursionsPerPage { get; } = 3;

        public string Region { get; set; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = string.Empty;

        public ExcursionSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalExcursionsCount { get; set; }

        public IEnumerable<string> Regions { get; set; } = null!;

        public IEnumerable<ExcursionServiceModel> Excursions { get; set; } = new List<ExcursionServiceModel>();



    }
}
