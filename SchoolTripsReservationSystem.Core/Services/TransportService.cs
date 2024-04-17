using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Infrastructure.Data.Common;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;

namespace SchoolTripsReservationSystem.Core.Services
{
    public class TransportService : ITransportService
    {
        private readonly IRepository repository;

        public TransportService(IRepository _repository)
        {
            repository = _repository;
        }


        public async Task CreateAsync(string name, int TransportCapacity)
        {
            await repository.AddAsync(new Transport()
            {
                Name = name,
                TransportCapacity = TransportCapacity
            });

            await repository.SaveChangesAsync();
        }
    }
}
