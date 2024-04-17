using Microsoft.EntityFrameworkCore;
using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Core.Models.Admin.User;
using SchoolTripsReservationSystem.Infrastructure.Data.Common;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;

namespace SchoolTripsReservationSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<ApplicationUser>()
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}"
                })
                .ToListAsync();
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;
            var user = await repository.GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }
            return result;
        }
    }
}
