﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Domain.UnitOfWork
{
    public interface IIdentity
    {
        public int Id { get; set; }
    }

    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }

        public IDbCommand CreateCommand();
        public IDbCommand CreateCommand(string commandLine);

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Transactional(Action action);
    }

    public interface IRepository<T> where T : IIdentity
    {
        IUnitOfWork UnitOfWork { get; }
        T GetById(int id);
        ICollection<T> GetAll();
        ICollection<T> GetAll(string where);
        void Update(T entity);
        void Insert(T entity);
        bool Delete(T entity);
        bool Delete(ICollection<T> entityes);
    }

    public abstract class DBUnitOfWork: IUnitOfWork
    {
        protected IDbConnection _DbConnection;
        protected IDbTransaction _DbTransaction;
        protected string _ConnectionString;

        public DBUnitOfWork(string connectionString)
        {
            _ConnectionString = connectionString;
            _DbConnection = InitializeConnection();
            _DbConnection.Open();
        }

        protected abstract IDbConnection InitializeConnection();

        public IDbConnection Connection => _DbConnection;

        public IDbTransaction Transaction => _DbTransaction;

        public IDbCommand CreateCommand()
        {
            IDbCommand command = Connection.CreateCommand();
            command.Transaction = Transaction;
            return command;
        }

        public IDbCommand CreateCommand(string commandLine)
        {
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
                if(_DbConnection.State == ConnectionState.Open)
                    _DbConnection.Close();
                _DbConnection.Dispose();
                _DbConnection = null;
            }
        }

        public void Transactional(Action action)
        {
            try
            {
                BeginTransaction();
                action();
                CommitTransaction();
            }
            catch(Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
                RollbackTransaction();
            }
        }
    }

    public abstract class AbstractDBRepository<T> : IRepository<T> where T : IIdentity
    {
        public AbstractDBRepository(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }
        protected abstract string TableName { get; }

        public IUnitOfWork UnitOfWork { get; private set; }

        protected abstract T DataRowToModel(IDataReader dr);

        public virtual bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(ICollection<T> entityes)
        {
            throw new NotImplementedException();
        }

        public virtual ICollection<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual ICollection<T> GetAll(string where)
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }

}