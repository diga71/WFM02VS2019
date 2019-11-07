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

        protected override IDbDataParameter CreateDataParameter()
        {
            return new SQLiteParameter();
        }

        protected override IDbConnection InitializeConnection()
        {
            IDbConnection connection = new SQLiteConnection(_ConnectionString);
            return connection;
        }

        protected override IQueryProvider InitializeQueryProvider()
        {
            return new SQLiteQueryProvider();
        }
    }

    public class SQLiteQueryProvider : IQueryProvider
    {
        public string DeleteString(string table, int identity)
        {
            throw new NotImplementedException();
        }

        public string InsertString(string table, params string[] values)
        {
            if (String.IsNullOrWhiteSpace(table) || values == null || values.Length == 0)
                throw new ApplicationException("Insert String not formatted");
            StringBuilder sb = new StringBuilder($"INSERT INTO {table} (");
            sb.Append(String.Join(",", values));
            sb.Append(") VALUES (");
            sb.Append("@" + String.Join(",@", values));
            sb.Append(");");
            sb.Append(" SELECT last_insert_rowid();");
            string joined = sb.ToString();
            return joined;
        }

        public string SelectString(string table, params string[] values)
        {
            throw new NotImplementedException();
        }

        public string UpdateString(string table, params string[] values)
        {
            throw new NotImplementedException();
        }
    }
}
