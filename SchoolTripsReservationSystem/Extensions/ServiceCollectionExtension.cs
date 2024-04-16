using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolTripsReservationSystem.Core.Contracts;
using SchoolTripsReservationSystem.Core.Services;
using SchoolTripsReservationSystem.Infrastructure.Data;
using SchoolTripsReservationSystem.Infrastructure.Data.Common;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;

namespace Micrososoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IExcursionService, ExcursionService>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<IReservationService, ReservationService>();
            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDefaultIdentity<ApplicationUser>(options =>
                { 
                    options.SignIn.RequireConfirmedAccount = false; 
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
