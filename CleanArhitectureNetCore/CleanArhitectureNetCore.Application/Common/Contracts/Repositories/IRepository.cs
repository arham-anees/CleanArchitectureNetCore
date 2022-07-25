using CleanArhitectureNetCore.Domain.Common;
using System;
using System.Collections.Generic;

namespace CleanArhitectureNetCore.Application.Common.Contracts.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(long Id);
        T Get(long Id);
        IEnumerable<T> Get();
    }
}
