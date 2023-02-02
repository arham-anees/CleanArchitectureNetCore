
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureNetCore.Infrastructure.Persistence.EfMariaDb
{
  public static class PersistenceExtension
  {
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<MariaDbContext>(options =>
      {
        options.UseMySql(configuration.GetConnectionString("MariaDb"), ServerVersion.AutoDetect(configuration.GetConnectionString("MariaDb")));
      });

      //services.AddTransient<IUnitOfWork, UnitOfWork>();

      return services;
    }
  }
}
