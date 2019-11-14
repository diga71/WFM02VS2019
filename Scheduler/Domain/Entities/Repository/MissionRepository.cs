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
            mission.Id = GetLong(m=>m.Id, dr);
            mission.IdOpe = GetLong(m => m.IdOpe, dr).Value;
            mission.IdAct = GetLong(m => m.IdAct, dr).Value;
            mission.Description = GetString(m => m.Description, dr);
            mission.StartDate = GetDate(m => m.StartDate, dr);
            mission.EndDate = GetDate(m => m.EndDate, dr);
            //Si riempie anche Operator? Activity?

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
            SetLong(m => m.IdOpe, entity.IdOpe, cmd);
            SetLong(m => m.IdAct, entity.IdAct, cmd);
            SetString(m => m.Description, entity.Description, cmd);

            SetDate(m => m.StartDate, entity.StartDate, cmd);
            SetDate(m => m.EndDate, entity.EndDate, cmd);
            if (identity)
            {
                SetLong(o => o.Id, entity.Id, cmd);
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
                return null;
                //return UnitOfWork.QueryProvider.InsertString(this.TableName, "IDOPE", "IDACT", "DESC", "DTIN", "DTEN");
            }
        }

        protected override string StandardUpdate
        {
            get
            {
                return UnitOfWork.QueryProvider.UpdateString<Mission>(this.TableName, ms => ms.IdOpe.ToString(), 
                    ms => ms.IdAct.ToString(),
                    ms => ms.Description,
                    ms => ms.StartDate.ToString(),
                    ms => ms.EndDate.ToString());
            }
        }
    }
}
