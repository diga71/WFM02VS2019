using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UnitOfWork
{
    public class UnitOfWorkFactory
    {
        public static IUnitOfWork Create()
        {
            return new SQLiteDBUnitOfWork($@"Data Source = C:\Dev\Tools\SQLite\DBS\Scheduling.db3; Version = 3; ");
        }
    }
}
