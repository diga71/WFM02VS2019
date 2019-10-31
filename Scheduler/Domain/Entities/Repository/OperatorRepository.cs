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

        protected override Operator FillModel(IDataReader dr)
        {
            Operator oper = new Operator();
            oper.Id = GetInt("ID", dr).Value;
            oper.EMail = GetString("MAIL", dr);
            oper.LastName = GetString("LSTNM", dr);
            oper.FirstName = GetString("FRSNM", dr);
            return oper;
        }
    }
}
