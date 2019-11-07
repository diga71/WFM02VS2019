using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SchedulingTest
{
    public class StuffTest
    {
        [Fact]
        public void ActivitiesLoad()
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
    }
}
