using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;
using SchoolTripsReservationSystem.Infrastructure.SeedDb;

namespace SchoolTripsReservationSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RegionConfiguration());
            builder.ApplyConfiguration(new TransportConfiguration());
            builder.ApplyConfiguration(new SchoolConfiguration());
            builder.ApplyConfiguration(new ExcursionConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Excursion> Excursions { get; set; } = null!;
        public DbSet<Region> Regions { get; set; } = null!;
        public DbSet<School> Schools { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<Transport> Transports { get; set; } = null!;


    }
}
