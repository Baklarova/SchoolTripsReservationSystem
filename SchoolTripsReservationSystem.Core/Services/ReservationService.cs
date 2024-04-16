using Microsoft.EntityFrameworkCore;
using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Core.Models.Reservation;
using SchoolTripsReservationSystem.Infrastructure.Data.Common;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;

namespace SchoolTripsReservationSystem.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository repository;

        public ReservationService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<ReservationExcursionServiceModel>> AllExcursionsAsync()
        {
            return await repository.AllReadOnly<Excursion>()
                .Select(e => new ReservationExcursionServiceModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Duration = e.Duration,
                    Description = e.Description,
                    PricePerStudent = e.PricePerStudent,
                    PricePerAdult = e.PricePerAdult,
                    RegionId = e.RegionId
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ReservationServiceModel>> AllReservaionByUserId(string userId)
        {
            return await repository.AllReadOnly<Reservation>()
                .Where(r => r.GroupLeaderId == userId)
                .Select(r => new ReservationServiceModel() 
                { 
                    Id = r.Id,
                    Excursion = r.Excursion.Name,
                    StartingDate = r.StartingDate.ToString(),
                    StudentCount = r.StudentCount,
                    EscortAdultCount = r.EscortAdultCount,
                    Transport = r.Transport.Name,
                    School = r.School.Name,
                    TeacherCount = r.TeacherCount,
                    TotalPrice = (r.StudentCount * r.Excursion.PricePerStudent) + (r.EscortAdultCount* r.Excursion.PricePerAdult)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ReservationSchoolServiceModel>> AllSchoolsAsync()
        {
            return await repository.AllReadOnly<School>()
                .Select(s => new ReservationSchoolServiceModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Eik = s.Eik,
                    Mol = s.Mol                    
                })
                .ToListAsync(); 
        }

        public async Task<IEnumerable<ReservationTransportServiceModel>> AllTransportsAsync()
        {
            return await repository.AllReadOnly<Transport>()
               .Select(t => new ReservationTransportServiceModel()
               {
                   Id = t.Id,
                   Name = t.Name,
                   TransportCapacity = t.TransportCapacity
               })
               .ToListAsync();
        }

        public async Task<int> CreateAsync(ReservationFormModel model, string userId)
        {
            DateTime departurDate = DateTime.Now;
            Reservation reservation = new Reservation()
            {
                ExcursionId = model.ExcursionId,
                StartingDate = departurDate,
                StudentCount = model.StudentCount,
                EscortAdultCount = model.EscortAdultCount,
                TransportId = model.TransportId,
                SchoolId = model.SchoolId,
                TeacherCount = model.TeacherCount,
                GroupLeaderId = userId
            };

            await repository.AddAsync(reservation);
            await repository.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task<bool> ExcursionExistsAsync(int excursionId)
        {
            return await repository.AllReadOnly<Excursion>()
                .AnyAsync(e => e.Id == excursionId);
        }

        public async Task<bool> SchoolExistsAsync(int schoolId)
        {
            return await repository.AllReadOnly<School>()
                .AnyAsync(s => s.Id == schoolId);
        }

        public async Task<bool> TransportExistsAsync(int transportId)
        {
            return await repository.AllReadOnly<Transport>()
                .AnyAsync(t => t.Id == transportId);
        }
    }
}
