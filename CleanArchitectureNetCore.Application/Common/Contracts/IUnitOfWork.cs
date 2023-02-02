using CleanArchitectureNetCore.Application.Common.Contracts.Repositories;
using System;

namespace CleanArchitectureNetCore.Application.Common.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IValuesRepository Values { get; }
        void SaveChanges();
        void Rollback();
    }
}
