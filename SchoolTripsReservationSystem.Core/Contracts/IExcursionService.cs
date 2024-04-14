using SchoolTripsReservationSystem.Core.Models.Home;

namespace SchoolTripsReservationSystem.Core.Contracts
{
    public interface IExcursionService
    {
        Task<IEnumerable<HomeViewModel>> OurNewOffers();
    }
}
