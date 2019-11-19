using Domain;
using Domain.Repository;
using Domain.Service;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SchedulingTest.Service
{
    public class ServiceOperatorTest
    {
        [Fact]
        public async void LoadOperators()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                OperatorService operatorService = new OperatorService(uow);
                List<Operator> ops = await operatorService.GetOperatorsAsync();
                //List<Operator> op2 = operatorService.GetOperatorsAsync2().Result;
            }
        }
    }
}
