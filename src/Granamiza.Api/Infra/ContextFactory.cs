using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Granamiza.Api.Infra
{
    [ExcludeFromCodeCoverage]
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext (string[] args)
        {
            return GenerateDbContext();
        }

        private static Context GenerateDbContext ()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Development.json", false)
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
            return new(optionsBuilder.Options);
        }
    }
}
