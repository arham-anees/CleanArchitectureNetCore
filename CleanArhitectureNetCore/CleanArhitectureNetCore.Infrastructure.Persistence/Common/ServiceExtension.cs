using CleanArhitectureNetCore.Application.Common.Contracts;
using CleanArhitectureNetCore.Infrastructure.Persistence.Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArhitectureNetCore.Infrastructure.Persistence.Common
{
    public static class ServiceExtension
    {
        public static void AddPersistence(this IServiceCollection services)
        {


            //services.AddTransient<DbContext, ApplicationDbContext>();

            services.AddTransient<IUnitOfWork, DapperUnitOfWork>();
        }
    }
}
