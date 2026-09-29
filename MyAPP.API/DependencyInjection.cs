using MyApp.Application;
using MyApp.Infrastructure;

namespace MyAPP.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection ADDAllDI(this IServiceCollection services,IConfiguration config)
        {
            services.AddApplicationDI();
            services.AddInfrastructureDI(config);

            return services;
        }
    }
}
