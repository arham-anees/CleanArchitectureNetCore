using CleanArhitectureNetCore.Application.Common.Contracts;
using CleanArhitectureNetCore.Domain.Common;
using CleanArhitectureNetCore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CleanArhitectureNetCore.Application.Services
{
    public class ValuesService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public ValuesService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        public List<Value> GetAllValues()
        {
            return _UnitOfWork.Values.Get()?.ToList();
        }
        public Value Create(string value, long userId)
        {
            Value val = new Value
            {
                Val = value
            };
            val.UpdateAudit(userId);//update audit properties
            using (_UnitOfWork)
            {
                try
                {

                    val = _UnitOfWork.Values.Add(val);//add to database
                    _UnitOfWork.SaveChanges();//
                }
                catch
                {
                    _UnitOfWork.Rollback();
                }
            }
            return val;
        }
    }
}
