using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Features.Country.Interfaces;
using MyApp.Application.Features.Country.Services;
using MyApp.Application.Features.State.Interfaces;
using MyApp.Application.Features.State.Services;
using MyApp.Infrastructure.Persistence;
using MyApp.Infrastructure.Repositories;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("ConStr")));
            //Country DI
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
            //State DI
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IStateService, StateService>();
            //City DI

            return services;
        }
    }
}
