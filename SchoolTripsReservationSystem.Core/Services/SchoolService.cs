using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Infrastructure.Data.Common;

namespace SchoolTripsReservationSystem.Core.Services
{
    internal class SchoolService : ISchoolService
    {
        private readonly IRepository repository;

        public SchoolService(IRepository _repository)
        {
            repository = _repository;
        }
        public Task CreateAsync(string name, string address, string eik, string mol)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SchoolWithEikExistsAsync(string eik)
        {
            throw new NotImplementedException();
        }
    }
}
