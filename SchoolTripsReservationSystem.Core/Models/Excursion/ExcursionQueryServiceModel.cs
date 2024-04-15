namespace SchoolTripsReservationSystem.Core.Models.Excursion
{
    public class ExcursionQueryServiceModel
    {
        public int TotalExcursionCount { get; set; }

        public IEnumerable<ExcursionServiceModel> Excursions { get; set; } = new List<ExcursionServiceModel>();
    }
}
