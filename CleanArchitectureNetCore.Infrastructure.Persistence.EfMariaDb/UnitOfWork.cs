
using CleanArchitectureNetCore.Application.Common.Contracts;
using CleanArchitectureNetCore.Application.Common.Contracts.Repositories;
using CleanArchitectureNetCore.Infrastructure.Persistence.EfMariaDb.Repositories;

using System.Linq;

namespace CleanArchitectureNetCore.Infrastructure.Persistence.EfMariaDb
{
  public class UnitOfWork : IUnitOfWork
  {
    private IValuesRepository _Values;
    private readonly MariaDbContext _Context;

    public IValuesRepository Values => _Values ??= new ValueRepository(_Context);

    public UnitOfWork(MariaDbContext context)
    {
      _Context = context;
    }

    public void Dispose()
    {
      
    }

    public void Rollback()
    {
      // roll back all detected changes
      _Context.ChangeTracker.Entries().ToList().ForEach(e => e.Reload());
    }

    public void SaveChanges()
    {
      _Context.SaveChanges();
    }
  }
}
