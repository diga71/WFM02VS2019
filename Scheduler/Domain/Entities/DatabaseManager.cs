using System.Data.SQLite;

namespace Domain
{
    public class DatabaseManager
    {
        public void DBConnection()
        {
            using (SQLiteConnection ObjConnection = new SQLiteConnection(@"Data Source=C:\Dev\Tools\SQLite\DBS\Scheduling.db3; Version=3;"))
            {
                ObjConnection.Open();
                using (SQLiteCommand ObjCommand = new SQLiteCommand("SELECT * FROM PERSON", ObjConnection))
                {

                }
            }
        }
    }
}
