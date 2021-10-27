using Notie;

namespace Granamiza.Api.Configs
{
    public static class ApiConfiguration
    {
        public static void AddApiConfiguration (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddNotie();
            services.AddDependencies(configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public static void UseApi (this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
