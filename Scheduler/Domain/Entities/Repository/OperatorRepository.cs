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
                StringBuilder sb = new StringBuilder($"INSERT INTO {TableName}");
                sb.Append(" (MAIL, LSTNM, FRSNM)");
                sb.Append(" VALUES (@MAIL, @LSTNM, @FRSNM);");
                sb.Append(" SELECT last_insert_rowid();");
                return sb.ToString();
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

            cmd.Parameters.Clear();
            IDbDataParameter dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = entity.EMail.Trim();
            dbparam.DbType = DbType.String;
            dbparam.ParameterName = "MAIL";
            dbparam.Size = 50;
            cmd.Parameters.Add(dbparam);
            dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = entity.LastName.Trim();
            dbparam.DbType = DbType.String;
            dbparam.ParameterName = "LSTNM";
            dbparam.Size = 50;
            cmd.Parameters.Add(dbparam);
            dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = entity.FirstName.Trim();
            dbparam.DbType = DbType.String;
            dbparam.ParameterName = "FRSNM";
            dbparam.Size = 50;
            cmd.Parameters.Add(dbparam);
        }
    }
}
