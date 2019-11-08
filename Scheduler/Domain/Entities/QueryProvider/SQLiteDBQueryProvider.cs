using System;
using System.Text;

namespace Domain.QueryProvider
{
    public class SQLiteDbQueryProvider : DbQueryProvider
    {
        public override string InsertString(string table, params string[] values)
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
    }
}
