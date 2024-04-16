using SchoolTripsReservationSystem.Core.Enumetations;
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

        Task<ExcursionQueryServiceModel> AllAsync(
            string? region = null,
            string? searchTerm = null,
            ExcursionSorting sorting = ExcursionSorting.Newest,
            int currentPage = 1,
            int excursionPerPege = 1);

        Task<IEnumerable<string>> AllRegionsNamesAsync();

        Task<bool> ExistsAsync(int id);

        Task<ExcursionDetailsServiceModel> ExcursionDetailsByIdAsync(int id);

        Task EditAsync(int excursionId, ExcursionFormModel model);

        Task<ExcursionFormModel?> GetExcursionFormModelByIdAsync(int id);
    }
}
