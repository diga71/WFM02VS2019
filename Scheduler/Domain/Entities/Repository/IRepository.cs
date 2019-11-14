using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Repository
{
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

    public abstract class AbstractDBRepository<T> : IRepository<T> where T : IIdentity//, new()
    {
        protected abstract string TableName { get; }

        protected virtual string StandardSelect => @$"SELECT {TableName}.* FROM {TableName}";

        protected abstract string StandardInsert { get; }

        protected abstract string StandardUpdate { get; }


        public IUnitOfWork UnitOfWork { get; private set; }

        public AbstractDBRepository(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        #region GetFromDB
        protected string GetString(Expression<Func<T, string>> lmdexpression, IDataReader dr)
        {
            if (dr == null)
                throw new ApplicationException("Invalid data Reader");
            if (lmdexpression == null)
                throw new ApplicationException("Invalid field to be Read");
            string field = ((MemberExpression)lmdexpression.Body).Member.Name;
            int pos = dr.GetOrdinal(field);
            if (pos >= 0 && pos < dr.FieldCount)
            {
                return dr.GetString(pos);
            }
            return null;
        }

        protected long GetLong(Expression<Func<T, long>> lmdexpression, IDataReader dr)
        {
            if (dr == null)
                throw new ApplicationException("Invalid data Reader");
            if (lmdexpression == null)
                throw new ApplicationException("Invalid field to be Read");
            string field = ((MemberExpression)lmdexpression.Body).Member.Name;
            int pos = dr.GetOrdinal(field.ToUpper());
            if (pos >= 0 && pos < dr.FieldCount)
            {
                return dr.GetInt64(pos);
            }
            throw new ApplicationException("Long value expected");
        }

        protected long? GetLong(Expression<Func<T, long?>> lmdexpression, IDataReader dr)
        {
            if (dr == null)
                throw new ApplicationException("Invalid data Reader");
            if (lmdexpression == null)
                throw new ApplicationException("Invalid field to be Read");
            string field = ((MemberExpression)lmdexpression.Body).Member.Name;
            int pos = dr.GetOrdinal(field.ToUpper());
            if (pos >= 0 && pos < dr.FieldCount)
            {
                return dr.GetInt64(pos);
            }
            return (long?)null;
        }

        protected double? GetDouble(Expression<Func<T, double?>> lmdexpression, IDataReader dr)
        {
            if (dr == null)
                throw new ApplicationException("Invalid data Reader");
            if (lmdexpression == null)
                throw new ApplicationException("Invalid field to be Read");
            string field = ((MemberExpression)lmdexpression.Body).Member.Name;
            int pos = dr.GetOrdinal(field.ToUpper());
            if (pos >= 0 && pos < dr.FieldCount)
            {
                return dr.GetDouble(pos);
            }
            return (double?)null;
        }

        protected double GetDouble(Expression<Func<T, double>> lmdexpression, IDataReader dr)
        {
            if (dr == null)
                throw new ApplicationException("Invalid data Reader");
            if (lmdexpression == null)
                throw new ApplicationException("Invalid field to be Read");
            string field = ((MemberExpression)lmdexpression.Body).Member.Name;
            int pos = dr.GetOrdinal(field.ToUpper());
            if (pos >= 0 && pos < dr.FieldCount)
            {
                return dr.GetDouble(pos);
            }
            throw new ApplicationException("Double value expected");
        }

        protected DateTime GetDate(Expression<Func<T, DateTime>> lmdexpression, IDataReader dr)
        {
            if (dr == null)
                throw new ApplicationException("Invalid data Reader");
            if (lmdexpression == null)
                throw new ApplicationException("Invalid field to be Read");

            string field = ((MemberExpression)lmdexpression.Body).Member.Name;
            int pos = dr.GetOrdinal(field);
            string data = null;
            if (pos >= 0 && pos < dr.FieldCount)
            {
                data = dr.GetString(pos);
            }
            if (String.IsNullOrWhiteSpace(data) || data.Length < 8)
                throw new ApplicationException("Date value expected");
            int year, month, day, hours, minutes, seconds;
            try
            {
                hours = minutes = seconds = 0;
                year = int.Parse(data.Substring(0, 4));
                month = int.Parse(data.Substring(4, 2));
                day = int.Parse(data.Substring(6, 2));
                if (data.Length == 12)
                {
                    hours = int.Parse(data.Substring(8, 2));
                    minutes = int.Parse(data.Substring(10, 2));
                }
                else if (field.Length == 14)
                {
                    hours = int.Parse(data.Substring(8, 2));
                    minutes = int.Parse(data.Substring(10, 2));
                    seconds = int.Parse(data.Substring(12, 2));
                }
                return new DateTime(year, month, day, hours, minutes, seconds);
            }
            catch
            {
                throw new ApplicationException("Date value expected");
            }
        }

        protected DateTime? GetDate(Expression<Func<T, DateTime?>> lmdexpression, IDataReader dr)
        {
            if (dr == null)
                throw new ApplicationException("Invalid data Reader");
            if (lmdexpression == null)
                throw new ApplicationException("Invalid field to be Read");

            string field = ((MemberExpression)lmdexpression.Body).Member.Name;
            int pos = dr.GetOrdinal(field);
            string data = null;
            if (pos >= 0 && pos < dr.FieldCount)
            {
                data = dr.GetString(pos);
            }
            if (String.IsNullOrWhiteSpace(data) || data.Length < 8)
                return (DateTime?) null;
            int year, month, day, hours, minutes, seconds;
            try
            {
                hours = minutes = seconds = 0;
                year = int.Parse(data.Substring(0, 4));
                month = int.Parse(data.Substring(4, 2));
                day = int.Parse(data.Substring(6, 2));
                if (data.Length == 12)
                {
                    hours = int.Parse(data.Substring(8, 2));
                    minutes = int.Parse(data.Substring(10, 2));
                }
                else if (field.Length == 14)
                {
                    hours = int.Parse(data.Substring(8, 2));
                    minutes = int.Parse(data.Substring(10, 2));
                    seconds = int.Parse(data.Substring(12, 2));
                }
                return new DateTime(year, month, day, hours, minutes, seconds);
            }
            catch
            {
                return (DateTime?)null;
            }
        }

        protected String PackDate(DateTime? dt)
        {
            if (dt == null || !dt.HasValue)
                return null;
            return $"{dt.Value.Year}{dt.Value.Month}{dt.Value.Day}{dt.Value.Hour}{dt.Value.Minute}{dt.Value.Second}";
        }
        #endregion

        #region SetToDB
        protected void SetString(Expression<Func<T, string>> lmdexpression, string value, IDbCommand cmd)
        {
            if (cmd == null)
                throw new ApplicationException("Invalid command");
            if (lmdexpression == null)
                throw new ApplicationException("Invalid field to be Read");
            string field = ((MemberExpression)lmdexpression.Body).Member.Name;
            IDbDataParameter dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.Value = value?.Trim();
            dbparam.DbType = DbType.String;
            dbparam.ParameterName = field;
            dbparam.Size = 50;
            cmd.Parameters.Add(dbparam);
        }

        protected void SetDouble(Expression<Func<T, double?>> lmdexpression, double? value, IDbCommand cmd)
        {
            if (cmd == null)
                throw new ApplicationException("Invalid command");
            if (lmdexpression == null)
                throw new ApplicationException("Invalid field to be Read");
            string field = ((MemberExpression)lmdexpression.Body).Member.Name;
            IDbDataParameter dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.ParameterName = field;
            dbparam.Value = value;
            dbparam.DbType = DbType.Double;
            cmd.Parameters.Add(dbparam);
        }

        protected void SetLong(Expression<Func<T, long>> lmdexpression, long value, IDbCommand cmd)
        {
            if (cmd == null)
                throw new ApplicationException("Invalid command");
            if (lmdexpression == null)
                throw new ApplicationException("Invalid field to be Read");
            string field = ((MemberExpression)lmdexpression.Body).Member.Name;
            IDbDataParameter dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.ParameterName = field;
            dbparam.Value = value;
            dbparam.DbType = DbType.Int64;
            cmd.Parameters.Add(dbparam);
        }

        protected void SetLong(Expression<Func<T, long?>> lmdexpression, long? value, IDbCommand cmd)
        {
            if (cmd == null)
                throw new ApplicationException("Invalid command");
            if (lmdexpression == null)
                throw new ApplicationException("Invalid field to be Read");
            string field = ((MemberExpression)lmdexpression.Body).Member.Name;
            IDbDataParameter dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.ParameterName = field;
            dbparam.Value = value;
            dbparam.DbType = DbType.Int64;
            cmd.Parameters.Add(dbparam);
        }

        protected void SetDate(Expression<Func<T, DateTime?>> lmdexpression, DateTime? value, IDbCommand cmd)
        {
            if (cmd == null)
                throw new ApplicationException("Invalid command");
            if (lmdexpression == null)
                throw new ApplicationException("Invalid field to be Read");
            string field = ((MemberExpression)lmdexpression.Body).Member.Name;
            string valueStr = PackDate(value);
            IDbDataParameter dbparam = this.UnitOfWork.CreateDbDataParameter();
            dbparam.ParameterName = field;
            dbparam.Value = valueStr;
            dbparam.DbType = DbType.Int64;
            cmd.Parameters.Add(dbparam);
        }
        #endregion
        protected abstract T FillModel(IDataReader dr);
        protected abstract void FillInsertParameters(IDbCommand cmd, T entity);
        protected abstract void FillUpdateParameters(IDbCommand cmd, T entity);

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
            List<T> retVal = new List<T>();
            var cmd = UnitOfWork.CreateCommand(this.StandardSelect);
            IDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                retVal.Add(this.FillModel(dr));
            }
            return retVal;
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
            if (entity == null)
                throw new ApplicationException("Insert Entity Null");
            var cmd = UnitOfWork.CreateCommand(StandardInsert);
            FillInsertParameters(cmd, entity);
            entity.Id = (long)cmd.ExecuteScalar();
        }


        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ApplicationException("Insert Entity Null");
            var cmd = UnitOfWork.CreateCommand(StandardUpdate);
            FillUpdateParameters(cmd, entity);
            var ret = (long)cmd.ExecuteNonQuery();
        }
    }

}
