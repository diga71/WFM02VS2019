using Domain.UnitOfWork;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Repository
{
    public class MissionRepository : AbstractDBRepository<Mission>
    {
        public MissionRepository(IUnitOfWork uow) : base(uow)
        {

        }

        protected override string TableName => "Mission";

        

        protected override Mission FillModel(IDataReader dr)
        {
            Mission mission = new Mission();
            mission.Id = GetInt("ID", dr).Value;
            mission.Description = GetString("DESC", dr);
            mission.StartDate = GetDate("DTIN", dr);
            return mission;
        }

        


        protected override string StandardSelect
        {
            get { return @$"SELECT {TableName}.*, Activity.*, Operator.* 
                    FROM {TableName} 
                    INNER JOIN Activity ON Activity.ID = Mission.IDACT 
                    LEFT JOIN Operator ON Operator.ID = Mission.IDOPE"; }
        }
    }
}
