using SchoolTripsReservationSystem.Core.Contracts;

namespace SchoolTripsReservationSystem.Core.Models.Excursion
{
    public class ExcursionDetailsModel : IExcursionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

    }
}
