using CleanArchitectureNetCore.Application.Common.Contracts;
using CleanArchitectureNetCore.Application.Common.Contracts.Repositories;
using CleanArchitectureNetCore.Infrastructure.Persistence.Dapper.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CleanArchitectureNetCore.Infrastructure.Persistence.Dapper
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        #region UNIT OF WORK
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;
        #endregion
        #region PRIVATE REPOSITORIES

        private IValuesRepository _Values;
        #endregion

        #region REPOSITORIES GET

        public IValuesRepository Values { get { if (_Values == null) { _Values = new ValuesRepository(_transaction); } return _Values; } }
        #endregion

        #region CONSTRUCTOR
        public DapperUnitOfWork(IConfiguration configuration)
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = configuration.GetConnectionString("default");
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }
        #endregion

        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            catch
            {
                throw;
            }
            finally
            {
                _transaction.Dispose();
                resetRepositories();
            }
        }

        public void SaveChanges()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }
        private void resetRepositories()
        {
            _Values = null;
        }
        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }
        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~DapperUnitOfWork()
        {
            dispose(false);
        }
    }
}
