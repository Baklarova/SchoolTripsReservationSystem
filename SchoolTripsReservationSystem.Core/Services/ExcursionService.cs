using Microsoft.EntityFrameworkCore;
using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Core.Enumetations;
using SchoolTripsReservationSystem.Core.Models.Excursion;
using SchoolTripsReservationSystem.Core.Models.Home;
using SchoolTripsReservationSystem.Infrastructure.Data.Common;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;

namespace SchoolTripsReservationSystem.Core.Services
{
    public class ExcursionService : IExcursionService
    {
        private readonly IRepository repository;

        public ExcursionService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<ExcursionQueryServiceModel> AllAsync(
            string? region = null,
            string? searchTerm = null, 
            ExcursionSorting sorting = ExcursionSorting.Newest, 
            int currentPage = 1, 
            int excursionPerPege = 1)
        {
            var excursionsToShow = repository.AllReadOnly<Excursion>();

            if (region != null)
            {
                excursionsToShow = excursionsToShow
                    .Where(e => e.Region.Name == region);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                excursionsToShow = excursionsToShow
                    .Where(e => (e.Name.ToLower().Contains(normalizedSearchTerm) ||
                                  e.Description.ToLower().Contains(normalizedSearchTerm)));
            }

            excursionsToShow = sorting switch 
            { 
                ExcursionSorting.Price => excursionsToShow
                    .OrderBy(e => e.PricePerStudent),
                ExcursionSorting.Duration => excursionsToShow
                    .OrderByDescending(e => e.Duration),
                _ => excursionsToShow
                    .OrderByDescending(e => e.Id)
            };

            var excursions = await excursionsToShow
                .Skip((currentPage - 1) * excursionPerPege)
                .Take(excursionPerPege)
                .Select(e => new ExcursionServiceModel() 
                {
                    Id = e.Id,
                    Name = e.Name,
                    Duration = e.Duration,
                    PricePerStudent = e.PricePerStudent
                })
                .ToListAsync();

            int totalExcursions = await excursionsToShow.CountAsync();

            return new ExcursionQueryServiceModel()
            {
                Excursions = excursions,
                TotalExcursionCount = totalExcursions
            };
        }

        public async Task<IEnumerable<ExcursionRegionServiseModel>> AllRegionsAsync()
        {
            return await repository.AllReadOnly<Region>()
                .Select(r => new ExcursionRegionServiseModel()
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllRegionsNamesAsync()
        {
            return await repository.AllReadOnly<Region>()
                .Select(r => r.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<int> CreateAsync(ExcursionFormModel model)
        {
            Excursion excursion = new Excursion()
            {
                Name = model.Name,
                Duration = model.Duration,
                Description = model.Description,
                PricePerStudent = model.PricePerStudent,
                PricePerAdult = model.PricePerAdult,
                RegionId = model.RegionId
            };

            await repository.AddAsync(excursion);
            await repository.SaveChangesAsync();

            return excursion.Id;
        }

        public async Task EditAsync(int excursionId, ExcursionFormModel model)
        {
            var excursion = await repository.GetByIdAsync<Excursion>(excursionId);

            if (excursion != null)
            {
                excursion.Name = model.Name;    
                excursion.Duration = model.Duration;
                excursion.Description = model.Description;
                excursion.RegionId = model.RegionId;
                excursion.PricePerStudent = model.PricePerStudent;
                excursion.PricePerAdult = model.PricePerAdult;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<ExcursionDetailsServiceModel> ExcursionDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Excursion>()
                .Where(e => e.Id == id)
                .Select(e => new ExcursionDetailsServiceModel()
                {
                    Id = e.Id, 
                    Name = e.Name,
                    Duration =  e.Duration,
                    Description = e.Description,
                    PricePerStudent = e.PricePerStudent,
                    PricePerAdult= e.PricePerAdult,
                    Region = e.Region.Name
                })
                .FirstAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Excursion>()
                .AnyAsync(e => e.Id == id);
        }

        public async Task<ExcursionFormModel?> GetExcursionFormModelByIdAsync(int id)
        {
            var excursion = await repository.AllReadOnly<Excursion>()
                .Where(e => e.Id == id)
                .Select(e => new ExcursionFormModel()
                {
                    Name = e.Name,
                    Duration = e.Duration,
                    Description = e.Description,
                    PricePerStudent = e.PricePerStudent,
                    PricePerAdult = e.PricePerAdult,
                    RegionId = e.RegionId
                })
                .FirstOrDefaultAsync();

            if (excursion != null)
            {
                excursion.Regions = await AllRegionsAsync();
            }

            return excursion;
        }

        public async Task<IEnumerable<HomeViewModel>> OurNewOffersAsync()
        {
            return await repository
                .AllReadOnly<Excursion>()
                .OrderByDescending(e => e.Id)
                .Take(2)
                .Select(e => new HomeViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    PricePerStudent = e.PricePerStudent,
                    PricePerAdult = e.PricePerAdult,
                    RegionId = e.RegionId                   
                })
                .ToListAsync();
        }

        public async Task<bool> RegionExistsAsync(int regionId)
        {
            return await repository.AllReadOnly<Region>()
                .AnyAsync(r => r.Id == regionId);
        }
    }
}
