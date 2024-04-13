using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTripsReservationSystem.Infrastructure.SeedDb
{
    internal class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
               .HasOne(r => r.Excursion)
               .WithMany(e => e.Reservations)
               .HasForeignKey(r => r.ExcursionId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(r => r.Transport)
               .WithMany(e => e.Reservations)
               .HasForeignKey(r => r.TransportId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(r => r.School)
              .WithMany(e => e.Reservations)
              .HasForeignKey(r => r.SchoolId)
              .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Reservation[] { data.FirstReservation, data.SecondReservation });
        }
    }
}
