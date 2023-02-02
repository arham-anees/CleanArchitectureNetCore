using CleanArchitectureNetCore.Application.Common.Contracts.Repositories;
using CleanArchitectureNetCore.Domain.Entities;
using CleanArchitectureNetCore.Infrastructure.Persistence.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureNetCore.Infrastructure.Persistence.Dapper.Repositories
{
    public class ValuesRepository : RepositoryBase, IValuesRepository
    {


        public ValuesRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public Value Add(Value entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            return base.AddOrUpdate<Value>(Procedures.InsertValue, new { val = entity.Val });
        }

        public Value Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public Value Get(long Id)
        {
            return base.Get<Value>(Procedures.GetValue, Id);
        }

        public IEnumerable<Value> Get()
        {
            return new Value[] {
                new Value{Val="test 1"},
                new Value{Val="test 2"},
                new Value{Val="test 3"},
            };
            return Connection.Query<Value>(
                Procedures.GetAllValues,
                param: null,
                transaction: base.Transaction,
                commandType: CommandType.StoredProcedure
            );
        }

        public Value Update(Value entity)
        {
            throw new NotImplementedException();
        }
    }
}
