using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftP.ApiDotNet.Application.Services;
using SoftP.ApiDotNet.Application.Services.Interfaces;

namespace SoftP.ApiDotNet.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFinanceService, FinanceService>();
            return services;
        }
    }
}
