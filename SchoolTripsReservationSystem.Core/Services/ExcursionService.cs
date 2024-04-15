using Microsoft.EntityFrameworkCore;
using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Core.Models.Excursion;
using SchoolTripsReservationSystem.Core.Models.Home;
using SchoolTripsReservationSystem.Core.Models.Region;
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
