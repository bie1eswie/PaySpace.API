using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PaySpace.Data.Abstract;
using PaySpace.Data.Respository;
using PaySpace.Service.Abstract;
using PaySpace.Service.Implementation;

namespace PaySpace.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICalculatorService, CalculatorService>();
            services.AddScoped<ICalculatorFactory,CalculatorFactory>();
            services.AddScoped<IPaySpaceRepository,PaySpaceRepository>();
            return services;
        }

        public static void ApplyMigration(this IApplicationBuilder app,ILogger logger)
        {
            try
            {
                logger.LogInformation($"Applying {typeof(PaySpaceContext).Name} Migrations");
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<PaySpaceContext>();
                    var pendingMigrations = context?.Database.GetPendingMigrations().ToList();
                    if (pendingMigrations != null && pendingMigrations.Any())
                    {
                        context.Database.Migrate();
                    }
                    else
                    {
                        logger.LogInformation($"No Migrations to apply {typeof(PaySpaceContext).Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Applying migrations threw an exception: {Message}", ex.Message);
            }

            logger.LogInformation($"Migrations {typeof(PaySpaceContext).Name} Completed");
        }
    }
}
