
using CleanArchitectureNetCore.Application.Common.Contracts;
using CleanArchitectureNetCore.Infrastructure.Persistence.Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureNetCore.Infrastructure.Persistence.Common
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
