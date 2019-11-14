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

        protected override void FillInsertParameters(IDbCommand cmd, Activity entity)
        {
            if (cmd == null)
                throw new ApplicationException("Null Command");
            if (entity == null)
                throw new ApplicationException("Null Entity");
            FillParametersCore(cmd, entity, false);
        }

        protected override void FillUpdateParameters(IDbCommand cmd, Activity entity)
        {
            if (cmd == null)
                throw new ApplicationException("Null Command");
            if (entity == null)
                throw new ApplicationException("Null Entity");

            FillParametersCore(cmd, entity, true);
        }

        private void FillParametersCore(IDbCommand cmd, Activity entity, bool identity)
        {
            if (cmd == null)
                throw new ApplicationException("Null Command");
            if (entity == null)
                throw new ApplicationException("Null Entity");
            //"EFFRT", "DESC"
            cmd.Parameters.Clear();
            SetString(o => o.Description, entity.Description?.Trim(), cmd);
            SetDouble(o => o.Effort, entity.Effort, cmd);
            if (identity)
            {
                SetLong(o => o.Id, entity.Id, cmd);
            }
        }

        protected override Activity FillModel(IDataReader dr)
        {
            Activity activity = new Activity();
            activity.Id = GetLong(ac => ac.Id, dr);
            activity.Effort = GetDouble(ac => ac.Effort, dr);
            activity.Description = GetString(ac => ac.Description, dr);
            return activity;
        }

        protected override string StandardInsert
        {
            get
            {
                return UnitOfWork.QueryProvider.InsertString<Activity>(this.TableName, ac => ac.Description, ac => ac.Effort.ToString());
            }
        }

        protected override string StandardUpdate
        {
            get
            {
                return UnitOfWork.QueryProvider.UpdateString<Activity>(this.TableName, ac => ac.Effort.ToString(), ac => ac.Description);
            }
        }
    }
}
