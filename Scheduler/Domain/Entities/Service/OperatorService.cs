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

        private List<Operator> GetOperators()
        {
            OperatorRepository operatorRepository = new OperatorRepository(this.UnitOfWork);
            var operators = operatorRepository.GetAll();
            return operators.ToList();
        }
    }
}
