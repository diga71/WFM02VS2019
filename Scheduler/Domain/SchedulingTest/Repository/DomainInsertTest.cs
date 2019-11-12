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
        public void OperatorInsert()
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

        [Fact]
        public void MissionInsert()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                ActivityRepository activityRepository = new ActivityRepository(uow);
                OperatorRepository operatorRepository = new OperatorRepository(uow);
                MissionRepository missionRepository = new MissionRepository(uow);
                var fA = activityRepository.GetAll().FirstOrDefault();
                var fO = operatorRepository.GetAll().FirstOrDefault();
                Mission newMission = new Mission()
                {
                    Description = "OnlyForTest",
                    Operator = fO,
                    Activity = fA,
                    StartDate = DateTime.Now
                };
                missionRepository.Insert(newMission);
            }
        }
    }
}
