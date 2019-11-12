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

        protected override void FillInsertParameters(IDbCommand cmd, Mission entity)
        {
            if (cmd == null)
                throw new ApplicationException("Null Command");
            if (entity == null)
                throw new ApplicationException("Null Entity");
            FillParametersCore(cmd, entity, false);
        }

        private void FillParametersCore(IDbCommand cmd, Mission entity, bool identity)
        {
            if (cmd == null)
                throw new ApplicationException("Null Command");
            if (entity == null)
                throw new ApplicationException("Null Entity");
            //"IDOPE", "IDACT", "DESC", "DTIN", "DTEN"
            cmd.Parameters.Clear();
            IDbDataParameter dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = entity.Operator != null ? entity.Operator.Id : (long?) null;
            dbparam.DbType = DbType.Int64;
            dbparam.ParameterName = "IDOPE";
            cmd.Parameters.Add(dbparam);

            dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = entity.Activity != null ? entity.Activity.Id : (long?)null;
            dbparam.DbType = DbType.Int64;
            dbparam.ParameterName = "IDACT";
            cmd.Parameters.Add(dbparam);

            dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = entity.Description?.Trim();
            dbparam.DbType = DbType.String;
            dbparam.ParameterName = "DESC";
            dbparam.Size = 50;
            cmd.Parameters.Add(dbparam);

            dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = PackDate(entity.StartDate);
            dbparam.DbType = DbType.String;
            dbparam.ParameterName = "DTIN";
            dbparam.Size = 50;
            cmd.Parameters.Add(dbparam);

            dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = PackDate(entity.EndDate);
            dbparam.DbType = DbType.String;
            dbparam.ParameterName = "DTEN";
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

        protected override void FillUpdateParameters(IDbCommand cmd, Mission entity)
        {
            if (cmd == null)
                throw new ApplicationException("Null Command");
            if (entity == null)
                throw new ApplicationException("Null Entity");
            FillParametersCore(cmd, entity, true);
        }

        protected override string StandardSelect
        {
            get { return @$"SELECT {TableName}.*, Activity.*, Operator.* 
                    FROM {TableName} 
                    INNER JOIN Activity ON Activity.ID = Mission.IDACT 
                    LEFT JOIN Operator ON Operator.ID = Mission.IDOPE"; }
        }

        protected override string StandardInsert
        {
            get
            {
                return UnitOfWork.QueryProvider.InsertString(this.TableName, "IDOPE", "IDACT", "DESC", "DTIN", "DTEN");
            }
        }

        protected override string StandardUpdate
        {
            get
            {
                return UnitOfWork.QueryProvider.UpdateString(this.TableName, "IDOPE", "IDACT", "DESC", "DTIN", "DTEN");
            }
        }
    }
}
