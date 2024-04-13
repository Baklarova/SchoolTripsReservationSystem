using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;

namespace SchoolTripsReservationSystem.Infrastructure.SeedDb
{
    internal class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            var data = new SeedData();

            builder.HasData(new Region[] { data.NortheastRegion, data.NorthwestRegion, data.SouthwestRegion, data.SoutheastRegion });
        }
    }
}
