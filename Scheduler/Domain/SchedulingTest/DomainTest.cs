using Domain;
using Domain.Repository;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using Xunit;

namespace SchedulingTest
{
    public class DomainTest
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
