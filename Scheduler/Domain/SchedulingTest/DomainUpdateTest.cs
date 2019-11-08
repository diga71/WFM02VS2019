using Domain;
using Domain.Repository;
using Domain.UnitOfWork;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace SchedulingTest
{
    public class DomainDomainUpdateTestInsertTest
    {
        [Fact]
        public void OperatorUpdate()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                OperatorRepository operatorRepository = new OperatorRepository(uow);
                var operators = operatorRepository.GetAll();
                if (operators.Count > 0)
                {
                    Operator myoperator = operators.FirstOrDefault();
                    myoperator.EMail += " (up)";
                    operatorRepository.Update(myoperator);
                }
            }
        }
    }
}
