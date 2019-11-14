using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Repository
{
    public class OperatorRepository : AbstractDBRepository<Operator>
    {
        public OperatorRepository(IUnitOfWork uow) : base(uow)
        {

        }

        protected override string TableName => "Operator";

        protected override string StandardInsert
        {
            get
            {
                return UnitOfWork.QueryProvider.InsertString<Operator>(this.TableName, op=>op.EMail, op => op.FirstName, op => op.LastName);
            }
        }

        protected override string StandardUpdate
        {
            get
            {
                return UnitOfWork.QueryProvider.UpdateString<Operator>(this.TableName, 
                    op=>op.EMail, 
                    op => op.LastName, 
                    op => op.FirstName);
            }
        }

        protected override Operator FillModel(IDataReader dr)
        {
            Operator oper = new Operator();
            oper.Id = GetLong(o=>o.Id, dr);
            oper.EMail = GetString(o => o.EMail, dr);
            oper.LastName = GetString(o => o.LastName, dr);
            oper.FirstName = GetString(o => o.FirstName, dr);
            return oper;
        }

        protected override void FillInsertParameters(IDbCommand cmd, Operator entity)
        {
            if (cmd == null)
                throw new ApplicationException("Null Command");
            if (entity == null)
                throw new ApplicationException("Null Entity");
            FillParametersCore(cmd, entity, false);
        }

        protected override void FillUpdateParameters(IDbCommand cmd, Operator entity)
        {
            if (cmd == null)
                throw new ApplicationException("Null Command");
            if (entity == null)
                throw new ApplicationException("Null Entity");

            FillParametersCore(cmd, entity, true);
        }

        private void FillParametersCore(IDbCommand cmd, Operator entity, bool identity)
        {
            if (cmd == null)
                throw new ApplicationException("Null Command");
            if (entity == null)
                throw new ApplicationException("Null Entity");

            cmd.Parameters.Clear();
            SetString(o => o.EMail, entity.EMail, cmd);
            SetString(o => o.LastName, entity.LastName, cmd);
            SetString(o => o.FirstName, entity.FirstName, cmd);
            if(identity)
            {
                SetLong(o => o.Id, entity.Id, cmd);
            }
        }
    }
}
