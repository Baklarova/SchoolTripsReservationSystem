using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTripsReservationSystem.Core.Contracts
{
    public interface ISchoolService
    {
        Task<bool> SchoolWithEikExistsAsync(string eik);

        Task CreateAsync(string name, string address, string eik, string mol);
    }
}
