using CleanArchitectureNetCore.Domain.Common;
using System;
using System.Collections.Generic;

namespace CleanArchitectureNetCore.Application.Common.Contracts.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(long id);
        T Get(long id);
        IEnumerable<T> Get();
    }
}
