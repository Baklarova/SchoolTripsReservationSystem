using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;

namespace SchoolTripsReservationSystem.Infrastructure.SeedDb
{
    internal class ExcursionConfiguration : IEntityTypeConfiguration<Excursion>
    {
        public void Configure(EntityTypeBuilder<Excursion> builder)
        {
            builder
                .HasOne(r => r.Region)
                .WithMany(e => e.Excursions)
                .HasForeignKey(r => r.RegionId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Excursion[] { data.FirstExcursion, data.SecondExcursion, data.ThirdExcursion });
        }
    }
}
