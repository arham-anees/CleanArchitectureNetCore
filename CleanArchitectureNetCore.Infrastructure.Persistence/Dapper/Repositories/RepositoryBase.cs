using CleanArchitectureNetCore.Application.Common.Contracts.Repositories;
using CleanArchitectureNetCore.Domain.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureNetCore.Infrastructure.Persistence.Dapper.Repositories
{
    public class RepositoryBase
    {
        protected IDbTransaction Transaction { get; private set; }
        protected IDbConnection Connection { get { return Transaction.Connection; } }
        public RepositoryBase(IDbTransaction transaction)
        {
            Transaction = transaction;
        }

        public TEntity AddOrUpdate<TEntity>(string procedure, object parameters) where TEntity : BaseEntity
        {
            return Connection.Query<TEntity>(
            procedure,
              param: parameters,
              transaction: Transaction,
              commandType: CommandType.StoredProcedure
         ).FirstOrDefault();
        }

        public void Delete<TEntity>(string procedure, long id) where TEntity : BaseEntity
        {
            Connection.Query<TEntity>(
             procedure,
               param: new { id = id },
               transaction: Transaction,
               commandType: CommandType.StoredProcedure
          );
        }

        public TEntity Get<TEntity>(string procedure, long id) where TEntity : BaseEntity
        {
            return Connection.Query<TEntity>(
             procedure,
               param: new { id = id },
               transaction: Transaction,
               commandType: CommandType.StoredProcedure
          ).FirstOrDefault();
        }
        public List<TEntity> Get<TEntity>(string procedure) where TEntity : BaseEntity
        {
            return Connection.Query<TEntity>(
              procedure,
                param: null,
                transaction: Transaction,
                commandType: CommandType.StoredProcedure
           ).AsList();
        }

    }
}
