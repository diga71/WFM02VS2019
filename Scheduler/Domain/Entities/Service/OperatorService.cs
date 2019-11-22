using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repository;
using Domain.UnitOfWork;

namespace Domain.Service
{
    public class OperatorService : AbstractService
    {
        public OperatorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Task<List<Operator>> GetOperatorsAsync()
        {
            return Task.Run(() => GetOperators());
        }

        public Task<Operator> RetrieveOperatorAsync(long id)
        {
            return Task.Run(() => RetrieveOperator(id));
        }

        public Task<Operator> UpdateOperatorsync(Operator wfOperator)
        {
            return Task.Run(() => UpdateOperator(wfOperator));
        }

        public Task<Operator> CreateOperatorAsync(Operator wfOperator)
        {
            return Task.Run(() => CreateOperator(wfOperator));
        }

        private List<Operator> GetOperators()
        {
            OperatorRepository operatorRepository = new OperatorRepository(this.UnitOfWork);
            var operators = operatorRepository.GetAll();
            return operators.ToList();
        }

        public Operator UpdateOperator(Operator wfOperator)
        {
            OperatorRepository operatorRepository = new OperatorRepository(this.UnitOfWork);
            operatorRepository.Update(wfOperator);
            return wfOperator;
        }

        private Operator CreateOperator(Operator wfOperator)
        {
            OperatorRepository operatorRepository = new OperatorRepository(this.UnitOfWork);
            operatorRepository.Insert(wfOperator);
            return wfOperator;
        }

        public Operator RetrieveOperator(long id)
        {
            OperatorRepository operatorRepository = new OperatorRepository(this.UnitOfWork);
            return operatorRepository.GetById(id);
        }
    }
}
