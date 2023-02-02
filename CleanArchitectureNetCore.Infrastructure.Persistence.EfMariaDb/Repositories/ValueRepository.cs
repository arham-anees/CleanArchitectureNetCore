using CleanArchitectureNetCore.Application.Common.Contracts.Repositories;
using CleanArchitectureNetCore.Domain.Entities;

namespace CleanArchitectureNetCore.Infrastructure.Persistence.EfMariaDb.Repositories
{
  public class ValueRepository : BaseRepository<Value>, IValuesRepository
  {
    public ValueRepository(MariaDbContext context):base(context)
    {
    }

  }
}
