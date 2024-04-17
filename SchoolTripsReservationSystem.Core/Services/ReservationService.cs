using Microsoft.EntityFrameworkCore;
using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Core.Models.Admin;
using SchoolTripsReservationSystem.Core.Models.Reservation;
using SchoolTripsReservationSystem.Infrastructure.Data.Common;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;
using System.Data;
using System.Globalization;

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

        public async Task<IEnumerable<ReservationAllModel>> AllReservaionAsync()
        {
            return await repository.AllReadOnly<Reservation>()
                .Select(r => new ReservationAllModel()
                {
                    Id = r.Id,
                    Excursion = r.Excursion.Name,
                    StartingDate = r.StartingDate.ToString(),
                    StudentCount = r.StudentCount,
                    EscortAdultCount = r.EscortAdultCount,
                    Transport = r.Transport.Name,
                    School = r.School.Name,
                    GroupLeaderName = $"{r.GroupLeader.FirstName} {r.GroupLeader.LastName}",
                    TeacherCount = r.TeacherCount,
                    TotalPrice = (r.StudentCount * r.Excursion.PricePerStudent) + (r.EscortAdultCount * r.Excursion.PricePerAdult)
				})
                .ToListAsync();
        }

        public async Task<IEnumerable<ReservationServiceModel>> AllReservaionByUserId(string userId)
        {
            return await repository.AllReadOnly<Reservation>()
                .Where(r => r.GroupLeaderId == userId)
                .Where(r => r.IsApproved)
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

        public async Task ApproveReservationAsync(int reservationId)
        {
            var reservation = await repository.GetByIdAsync<Reservation>(reservationId);

            if (reservation != null && reservation.IsApproved == false)
            {
                reservation.IsApproved = true;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<int> CreateAsync(ReservationFormModel model, string userId)
        {
            DateTime departurDate = DateTime.Now;

            if (!DateTime.TryParseExact(model.StartingDate, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out departurDate))
            {
                throw new ArgumentException("Invalid date! Format must be: dd.MM.yyyy HH:mm:ss");
                
            }
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

        public async Task EditAsync(int reservationId, ReservationFormModel model)
        {
            var reservation = await repository.GetByIdAsync<Reservation>(reservationId);

            DateTime departurDate = DateTime.Now;

            if (!DateTime.TryParseExact(model.StartingDate, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out departurDate))
            {
                throw new ArgumentException("Invalid date! Format must be: dd.MM.yyyy HH:mm:ss");

            }

            if (reservation != null)
            {
                reservation.ExcursionId = model.ExcursionId;
                reservation.StartingDate = departurDate;
                reservation.StudentCount = model.StudentCount;
                reservation.EscortAdultCount = model.EscortAdultCount;
                reservation.TransportId = model.TransportId;
                reservation.SchoolId = model.SchoolId;
                reservation.TeacherCount = model.TeacherCount;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExcursionExistsAsync(int excursionId)
        {
            return await repository.AllReadOnly<Excursion>()
                .AnyAsync(e => e.Id == excursionId);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Reservation>()
                .AnyAsync(e => e.Id == id);
        }

        public async Task<ReservationFormModel?> GetReservationFormModelByIdAsync(int id)
        {
            
            var reservation = await repository.AllReadOnly<Reservation>()
                .Where(r => r.Id == id)
                .Select(r => new ReservationFormModel()
                {
                    ExcursionId = r.Id,
                    StartingDate = r.StartingDate.ToString(),
                    StudentCount = r.StudentCount,
                    EscortAdultCount = r.EscortAdultCount,
                    TransportId = r.TransportId,
                    SchoolId = r.SchoolId,
                    TeacherCount = r.TeacherCount
                })
                .FirstOrDefaultAsync();

            if (reservation != null)
            {
                reservation.Excursions = await AllExcursionsAsync();
                reservation.Transports = await AllTransportsAsync();
                reservation.Schools = await AllSchoolsAsync();
            }

            return reservation;
        }

        public async Task<IEnumerable<ApproveReservationViewModel>> GetUnApprovedAsync()
        {
            return await repository.AllReadOnly<Reservation>()
                .Where(r => r.IsApproved == false)
                .Select(r => new ApproveReservationViewModel()
                {
                    ReservationId = r.Id,
                    ExcursionName = r.Excursion.Name,
                    StartingDate = r.StartingDate.ToString(),
                    StudentCount = r.StudentCount
                })
                .ToListAsync();
        }

        public async Task<bool> HasUserWithIdAsync(int reservationId, string userId)
        {
            return await repository.AllReadOnly<Reservation>()
                .AnyAsync(r => r.Id == reservationId && r.GroupLeaderId == userId);
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
