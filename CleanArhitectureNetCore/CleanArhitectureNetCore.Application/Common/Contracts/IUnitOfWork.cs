using CleanArhitectureNetCore.Application.Common.Contracts.Repositories;
using System;

namespace CleanArhitectureNetCore.Application.Common.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IValuesRepository Values { get; }
        void SaveChanges();
        void Rollback();
    }
}
