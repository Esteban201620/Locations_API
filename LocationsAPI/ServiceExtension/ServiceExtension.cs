using LocationsAPI.Dal.Ciudad;
using LocationsAPI.Dal.Departamento;
using LocationsAPI.Dal.Pais;
using LocationsAPI.Resources.Context;
using Microsoft.EntityFrameworkCore;

namespace LocationsAPI.ServiceExtension
{
    public static class ServiceExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration )
        {
            string? connectionString = configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
            });
        }

        public static void ConfigureInterfaces(this IServiceCollection services)
        {
            services.AddScoped<IPaisesDal, PaisesDal>();
            services.AddScoped<IDepartamentosDal, DepartamentosDal>();
            services.AddScoped<ICiudadesDal, CiudadesDal>();
        }
    }
}
