using Granamiza.Api.Infra;
using Granamiza.Api.Infra.Repositories;
using Granamiza.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Granamiza.Api.Configs
{
    public static class DiConfiguration
    {

        public static void AddDependencies (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfra(configuration);
            services.AddServices();
        }

        private static void AddInfra (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgreSQL") ?? string.Empty;
            services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IIncomeRepository, IncomeRepository>();
        }

        private static void AddServices (this IServiceCollection services)
        {
            services.AddScoped<IIncomeService, IncomeService>();
        }

    }
}

