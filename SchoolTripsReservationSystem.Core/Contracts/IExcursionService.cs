using SchoolTripsReservationSystem.Core.Models.Excursion;
using SchoolTripsReservationSystem.Core.Models.Home;
using SchoolTripsReservationSystem.Core.Models.Region;

namespace SchoolTripsReservationSystem.Core.Contracts
{
    public interface IExcursionService
    {
        Task<IEnumerable<HomeViewModel>> OurNewOffersAsync();

        Task<IEnumerable<ExcursionRegionServiseModel>> AllRegionsAsync();

        Task<bool> RegionExistsAsync(int regionId);

        Task<int> CreateAsync(ExcursionFormModel model);
    }
}
