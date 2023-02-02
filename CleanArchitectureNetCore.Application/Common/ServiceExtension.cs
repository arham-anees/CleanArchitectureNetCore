using CleanArchitectureNetCore.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureNetCore.Application.Common
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ValuesService>();
        }
    }
}
