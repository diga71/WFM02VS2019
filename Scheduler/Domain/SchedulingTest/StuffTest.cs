using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SchedulingTest
{
    public class StuffTest
    {
        [Fact]
        public void InsertTestQuery()
        {
            string[] str = new string[4] { "A", "B", "C", "D" };
            string table = "MYTABLE";
            StringBuilder sb = new StringBuilder($"INSERT INTO {table} (");
            sb.Append(String.Join(",", str));
            sb.Append(") VALUES (");
            sb.Append("@" + String.Join(",@", str));
            sb.Append(");");
            sb.Append(" SELECT last_insert_rowid();");
            string joined = sb.ToString();
            System.Diagnostics.Debug.WriteLine(joined);
        }

        [Fact]
        public void UpdateTestQuery()
        {
            string[] str = new string[4] { "A", "B", "C", "D" };
            long id = 100;
            string table = "MYTABLE";
            StringBuilder sb = new StringBuilder($"UPDATE {table} SET ");
            foreach(string s in str)
            {
                sb.Append($"{s}=@{s},");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append($" WHERE ID = {id}");
            string joined = sb.ToString();
            System.Diagnostics.Debug.WriteLine(joined);
        }
    }
}
