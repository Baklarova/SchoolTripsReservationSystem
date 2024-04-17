namespace SchoolTripsReservationSystem.Core.Contracts
{
    public interface ISchoolService
    {
        Task<bool> SchoolWithEikExistsAsync(string eik);

        Task CreateAsync(string name, string address, string eik, string mol);
    }
}
