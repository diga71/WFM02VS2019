using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.QueryProvider
{
    public interface IDbQueryProvider
    {
        string InsertString(string table, params string[] values); //Provare con le espressioni linq
        string SelectString(string table, params string[] values);
        string UpdateString(string table, params string[] values); //Provare con le espressioni linq
        string DeleteString(string table, int identity);
    }

    public abstract class DbQueryProvider : IDbQueryProvider
    {
        public virtual string DeleteString(string table, int identity)
        {
            throw new NotImplementedException();
        }

        public virtual string InsertString(string table, params string[] values)
        {
            throw new NotImplementedException();
        }

        public virtual string SelectString(string table, params string[] values)
        {
            throw new NotImplementedException();
        }

        public virtual string UpdateString(string table, params string[] values)
        {
            if (String.IsNullOrWhiteSpace(table) || values == null || values.Length == 0)
                throw new ApplicationException("Update String not formatted");
            StringBuilder sb = new StringBuilder($"UPDATE {table} SET ");
            foreach (string s in values)
            {
                sb.Append($"{s}=@{s},");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append($" WHERE ID = @ID");
            string joined = sb.ToString();
            return joined;
        }
    }
}
