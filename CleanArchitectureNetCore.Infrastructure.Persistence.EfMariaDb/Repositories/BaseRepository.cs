using CleanArchitectureNetCore.Application.Common.Contracts.Repositories;
using CleanArchitectureNetCore.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureNetCore.Infrastructure.Persistence.EfMariaDb.Repositories
{
  public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
  {
    private readonly MariaDbContext _Context;

    public BaseRepository(MariaDbContext context)
    {
      _Context = context;
    }
    public T Add(T entity)
    {
      entity.IsActive = true;
      _Context.Set<T>().Add(entity);
      return entity;
    }

    public T Delete(long Id)
    {
      var entity = _Context.Set<T>().Find(Id);
      entity.IsActive = false;
      _Context.Set<T>().Update(entity);
      return entity;
    }

    public T Get(long id)
    {
      return _Context.Set<T>().Where(x => x.IsActive).FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<T> Get()
    {
      return _Context.Set<T>().Where(x=>x.IsActive).ToList();
    }

    public T Update(T entity)
    {
      _Context.Set<T>().Update(entity);
      return entity;
    }
  }
}
