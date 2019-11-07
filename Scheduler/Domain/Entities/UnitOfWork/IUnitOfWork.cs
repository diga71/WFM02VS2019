using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Domain.UnitOfWork
{
    public interface IIdentity
    {
        public long Id { get; set; }
    }

    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        IQueryProvider QueryProvider { get; }
        public IDbCommand CreateCommand();
        public IDbCommand CreateCommand(string commandLine);
        public IDbDataParameter CreateDbDataParameter();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Transactional(Action action);
    }

    public interface IQueryProvider
    {
        string InsertString(string table, params string[] values); //Provare con le espressioni linq
        string SelectString(string table, params string[] values);
        string UpdateString(string table, params string[] values); //Provare con le espressioni linq
        string DeleteString(string table, int identity);
    }

    public abstract class DBUnitOfWork : IUnitOfWork
    {
        protected IDbConnection _DbConnection = null;
        protected IDbTransaction _DbTransaction = null;
        protected string _ConnectionString = null;
        protected IQueryProvider _QueryProvider = null;

        public DBUnitOfWork(string connectionString)
        {
            _ConnectionString = connectionString;
            _DbConnection = InitializeConnection();
            _QueryProvider = InitializeQueryProvider();
            _DbConnection.Open();
        }
        protected abstract IQueryProvider InitializeQueryProvider();
        protected abstract IDbConnection InitializeConnection();
        protected abstract IDbDataParameter CreateDataParameter();
        public IDbConnection Connection => _DbConnection;
        public IDbTransaction Transaction => _DbTransaction;
        public IQueryProvider QueryProvider => _QueryProvider;

        public IDbCommand CreateCommand()
        {
            IDbCommand command = Connection.CreateCommand();
            command.Transaction = Transaction;
            return command;
        }
        public IDbCommand CreateCommand(string commandLine)
        {
            if (String.IsNullOrEmpty(commandLine))
                throw new ApplicationException("Empty command line");
            IDbCommand command = Connection.CreateCommand();
            command.CommandText = commandLine.Trim();
            command.CommandType = CommandType.Text;
            command.Transaction = Transaction;
            return command;
        }
        public void BeginTransaction()
        {
            if (_DbTransaction == null)
            {
                _DbTransaction = _DbConnection.BeginTransaction();
            }
        }
        public void CommitTransaction()
        {
            if (_DbTransaction != null)
            {
                _DbTransaction.Commit();
                _DbTransaction = null;
            }
        }
        public void RollbackTransaction()
        {
            if (_DbTransaction != null)
            {
                _DbTransaction.Rollback();
                _DbTransaction = null;
            }
        }
        public void Dispose()
        {
            if (_DbTransaction != null)
            {
                _DbTransaction.Dispose();
                _DbTransaction = null;
            }
            if (_DbConnection != null)
            {
                if (_DbConnection.State == ConnectionState.Open)
                    _DbConnection.Close();
                _DbConnection.Dispose();
                _DbConnection = null;
            }
        }
        public void Transactional(Action action)
        {
            try
            {
                if (action == null)
                    return;
                BeginTransaction();
                action();
                CommitTransaction();
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
                RollbackTransaction();
            }
        }
        public IDbDataParameter CreateDbDataParameter()
        {
            return CreateDataParameter();
        }
    }

}
