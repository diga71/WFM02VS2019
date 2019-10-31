using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Repository
{
    public class ActivityRepository : AbstractDBRepository<Activity>
    {
        public ActivityRepository(IUnitOfWork uow) : base(uow)
        {

        }
        protected override string TableName => "Activity";

        protected override Activity FillModel(IDataReader dr)
        {
            Activity activity = new Activity();
            activity.Id = GetInt("ID", dr).Value;
            activity.Effort = GetDouble("EFFRT", dr);
            activity.Description = GetString("DESC", dr);
            return activity;
        }
    }
}
