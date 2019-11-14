using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.QueryProvider
{
    public interface IDbQueryProvider
    {
        //string InsertString(string table, params string[] values); //Provare con le espressioni linq
        string SelectString(string table, params string[] values);
        string UpdateString<T>(string table, params Expression<Func<T, String>>[] expression) where T : class, new();
        string DeleteString(string table, int identity);
        string InsertString<T>(string table, params Expression<Func<T, String>>[] expression) where T : class, new();
    }

    public abstract class DbQueryProvider : IDbQueryProvider
    {
        public virtual string DeleteString(string table, int identity)
        {
            throw new NotImplementedException();
        }

        //public virtual string InsertString(string table, params string[] values)
        //{
        //    throw new NotImplementedException();
        //}

        public virtual string InsertString<T>(string table, params Expression<Func<T, string>>[] expression) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public virtual string SelectString(string table, params string[] values)
        {
            throw new NotImplementedException();
        }

        protected List<string> FieldsFromParams<T>(params Expression<Func<T, String>>[] expression)
        {
            List<String> values = new List<string>();
            foreach (Expression<Func<T, String>> exp in expression)
            {
                var mbEx = exp.Body as MemberExpression;
                if (mbEx == null)
                {
                    var mbExM = exp.Body as MethodCallExpression;
                    MemberExpression imbEx = (MemberExpression)mbExM.Object;
                    string name = imbEx.Member.Name;
                    values.Add(name);
                }
                else
                {
                    values.Add(mbEx.Member.Name);
                }
            }
            if (values == null || values.Count == 0)
                throw new ApplicationException("Insert String not formatted");
            return values;
        }

        public virtual string UpdateString<T>(string table, params Expression<Func<T, String>>[] expressions) where T : class, new()
        {
            List<String> values = FieldsFromParams(expressions);
            if (String.IsNullOrWhiteSpace(table))
                throw new ApplicationException("Update String not formatted");
            if (String.IsNullOrWhiteSpace(table))
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
