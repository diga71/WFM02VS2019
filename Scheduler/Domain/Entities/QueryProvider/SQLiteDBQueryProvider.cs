using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.QueryProvider
{
    public class SQLiteDbQueryProvider : DbQueryProvider
    {
        public override string InsertString<T>(string table, params Expression<Func<T, String>>[] expressions) 
        {
            List<String> values = FieldsFromParams(expressions);
            if (String.IsNullOrWhiteSpace(table))
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
    }
}
