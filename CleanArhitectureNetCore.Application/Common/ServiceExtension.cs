using CleanArhitectureNetCore.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArhitectureNetCore.Application.Common
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ValuesService>();
        }
    }
}
