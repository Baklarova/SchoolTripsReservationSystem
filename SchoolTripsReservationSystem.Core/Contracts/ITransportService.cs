using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTripsReservationSystem.Core.Contracts
{
    public interface ITransportService
    {
        Task CreateAsync(string name, int TransportCapacity);
    }
}
