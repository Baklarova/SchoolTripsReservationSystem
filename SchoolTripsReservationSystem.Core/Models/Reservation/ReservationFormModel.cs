using SchoolTripsReservationSystem.Core.Models.Excursion;

namespace SchoolTripsReservationSystem.Core.Models.Reservation
{
    public class ReservationFormModel
    {
        public IEnumerable<ExcursionRegionServiseModel> Regions { get; set; }
    }
}
