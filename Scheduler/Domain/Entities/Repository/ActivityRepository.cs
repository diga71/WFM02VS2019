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
            IDbDataParameter dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = entity.Description?.Trim();
            dbparam.DbType = DbType.String;
            dbparam.ParameterName = "DESC";
            dbparam.Size = 50;
            cmd.Parameters.Add(dbparam);

            dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = entity.Effort;
            dbparam.DbType = DbType.Double;
            dbparam.ParameterName = "EFFRT";
            dbparam.Size = 50;
            cmd.Parameters.Add(dbparam);
            if (identity)
            {
                dbparam = this.UnitOfWork.CreateDbDataParameter();
                dbparam.Value = entity.Id;
                dbparam.DbType = DbType.Int64;
                dbparam.ParameterName = "ID";
                cmd.Parameters.Add(dbparam);
            }
        }

        protected override Activity FillModel(IDataReader dr)
        {
            Activity activity = new Activity();
            activity.Id = GetInt("ID", dr).Value;
            activity.Effort = GetDouble("EFFRT", dr);
            activity.Description = GetString("DESC", dr);
            return activity;
        }

        protected override string StandardInsert
        {
            get
            {
                return UnitOfWork.QueryProvider.InsertString(this.TableName, "EFFRT", "DESC");
            }
        }

        protected override string StandardUpdate
        {
            get
            {
                return UnitOfWork.QueryProvider.UpdateString(this.TableName, "EFFRT", "DESC");
            }
        }
    }
}
