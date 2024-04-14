using Microsoft.EntityFrameworkCore;
using SchoolTripsReservationSystem.Core.Contracts;
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

      
    }
}
