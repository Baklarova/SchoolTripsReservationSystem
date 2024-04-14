using Microsoft.EntityFrameworkCore;
using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Infrastructure.Data.Common;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;

namespace SchoolTripsReservationSystem.Core.Services
{
    internal class SchoolService : ISchoolService
    {
        private readonly IRepository repository;

        public SchoolService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task CreateAsync(string name, string address, string eik, string mol)
        {
            await repository.AddAsync(new School()
            {
                Name = name,
                Address = address,
                Eik = eik,
                Mol = mol
            });

            await repository.SaveChangesAsync();
                
        }

        public async Task<bool> SchoolWithEikExistsAsync(string eik)
        {
            return await repository.AllReadOnly<School>()
                .AnyAsync(s => s.Eik == eik);

        }
    }
}
