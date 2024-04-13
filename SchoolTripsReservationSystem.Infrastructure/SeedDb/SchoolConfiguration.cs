using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;

namespace SchoolTripsReservationSystem.Infrastructure.SeedDb
{
    internal class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            var data = new SeedData();

            builder.HasData(new School[] { data.FirstSchool, data.SecondSchool });
        }
    }
}
