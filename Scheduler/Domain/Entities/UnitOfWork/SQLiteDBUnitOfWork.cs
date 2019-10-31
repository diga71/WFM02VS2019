using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Domain.UnitOfWork
{
    public class SQLiteDBUnitOfWork : DBUnitOfWork
    {
        public SQLiteDBUnitOfWork(string connectioString) : base(connectioString)
        {
        }

        protected override IDbConnection InitializeConnection()
        {
            IDbConnection connection = new SQLiteConnection(_ConnectionString);
            return connection;
        }
    }
}
