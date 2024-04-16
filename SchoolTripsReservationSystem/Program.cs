using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Micrososoft.Extensions.DependencyInjection;
using SchoolTripsReservationSystem.ModelBinders;

namespace SchoolTripsReservationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationDbContext(builder.Configuration);
            builder.Services.AddApplicationIdentity(builder.Configuration);

            builder.Services.AddControllersWithViews(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            builder.Services.AddApplicationServices();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Excursion Details",
                    pattern: "/Excursion/Details/{id}/{information}",
                    defaults: new { Controller = "Excursion", Action = "Details"}
                    );
				endpoints.MapDefaultControllerRoute();
				endpoints.MapRazorPages();
			});
            
            app.Run();
        }
    }
}