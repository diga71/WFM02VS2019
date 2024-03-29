using Domain;
using Domain.Repository;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using Xunit;

namespace SchedulingTest
{
    public class DomainLoadTest
    {
        [Fact]
        public void ActivitiesLoad()
        {
            using(IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                ActivityRepository activityRepository = new ActivityRepository(uow);
                var activities = activityRepository.GetAll();
            }
        }

        [Fact]
        public void OperatorsLoad()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                OperatorRepository operatorRepository = new OperatorRepository(uow);
                var operators = operatorRepository.GetAll();
                foreach(Operator op in operators)
                {
                    long identity = op.Id;
                    Operator wfOperator = operatorRepository.GetById(identity);
                    Assert.Equal(op.GetSummary(), wfOperator.GetSummary());
                }
            }
        }

        [Fact]
        public void MissionsLoad()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                MissionRepository missionRepository = new MissionRepository(uow);
                var missions = missionRepository.GetAll();
            }
        }
    }
}
