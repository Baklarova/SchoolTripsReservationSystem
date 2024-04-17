﻿using SchoolTripsReservationSystem.Core.Models.Excursion;
using SchoolTripsReservationSystem.Core.Models.Reservation;

namespace SchoolTripsReservationSystem.Core.Contracts
{
    public interface IReservationService
    {
        Task<int> CreateAsync(ReservationFormModel model, string userId);

        Task<IEnumerable<ReservationExcursionServiceModel>> AllExcursionsAsync();

        Task<bool> ExcursionExistsAsync(int excursionId);

        Task<IEnumerable<ReservationTransportServiceModel>> AllTransportsAsync();

        Task<bool> TransportExistsAsync(int transportId);

        Task<IEnumerable<ReservationSchoolServiceModel>> AllSchoolsAsync();

        Task<bool> SchoolExistsAsync(int schoolId);

        Task<IEnumerable<ReservationServiceModel>> AllReservaionByUserId(string userId);

        Task<IEnumerable<ReservationAllModel>> AllReservaionAsync();

        Task<bool> ExistsAsync(int id);

        Task EditAsync(int reservationId, ReservationFormModel model);

        Task<ReservationFormModel?> GetReservationFormModelByIdAsync(int id);

        Task<bool> HasUserWithIdAsync(int reservationId, string userId);
    }
}
