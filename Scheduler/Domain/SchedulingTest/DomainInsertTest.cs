using Domain;
using Domain.Repository;
using Domain.UnitOfWork;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace SchedulingTest
{
    public class DomainInsertTest
    {
        [Fact]
        public void OperatorMailUpdate()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                OperatorRepository operatorRepository = new OperatorRepository(uow);
                Operator newoperator = new Operator()
                {
                    EMail = "jDoe@.terranovasoftware.eu",
                    FirstName = "John",
                    LastName = "Doe"
                };
                operatorRepository.Insert(newoperator);
            }
        }
    }
}
