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
                return UnitOfWork.QueryProvider.InsertString(this.TableName, "MAIL", "LSTNM", "FRSNM");
            }
        }

        protected override string StandardUpdate
        {
            get
            {
                return UnitOfWork.QueryProvider.UpdateString(this.TableName, "MAIL", "LSTNM", "FRSNM");
            }
        }

        protected override Operator FillModel(IDataReader dr)
        {
            Operator oper = new Operator();
            oper.Id = GetInt("ID", dr).Value;
            oper.EMail = GetString("MAIL", dr);
            oper.LastName = GetString("LSTNM", dr);
            oper.FirstName = GetString("FRSNM", dr);
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
            IDbDataParameter dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = entity.EMail?.Trim();
            dbparam.DbType = DbType.String;
            dbparam.ParameterName = "MAIL";
            dbparam.Size = 50;
            cmd.Parameters.Add(dbparam);
            dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = entity.LastName?.Trim();
            dbparam.DbType = DbType.String;
            dbparam.ParameterName = "LSTNM";
            dbparam.Size = 50;
            cmd.Parameters.Add(dbparam);
            dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = entity.FirstName?.Trim();
            dbparam.DbType = DbType.String;
            dbparam.ParameterName = "FRSNM";
            dbparam.Size = 50;
            cmd.Parameters.Add(dbparam);
            if(identity)
            {
                dbparam = this.UnitOfWork.CreateDbDataParameter();
                dbparam.Value = entity.Id;
                dbparam.DbType = DbType.Int64;
                dbparam.ParameterName = "ID";
                cmd.Parameters.Add(dbparam);
            }
        }
    }
}
