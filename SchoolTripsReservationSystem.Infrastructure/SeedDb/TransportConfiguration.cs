using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;

namespace SchoolTripsReservationSystem.Infrastructure.SeedDb
{
    internal class TransportConfiguration : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            var data = new SeedData();

            builder.HasData(new Transport[] { data.Microbus, data.Autobus32, data.Autobus55 });
        }
    }
}
