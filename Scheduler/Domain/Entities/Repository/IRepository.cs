using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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


        public IUnitOfWork UnitOfWork { get; private set; }

        public AbstractDBRepository(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }

        #region GetFromDB
        protected string GetString(string field, IDataReader dr)
        {
            int pos = dr.GetOrdinal(field);
            if (pos >= 0 && pos < dr.FieldCount)
            {
                return dr.GetString(pos);
            }
            return null;
        }

        protected int? GetInt(string field, IDataReader dr)
        {
            int pos = dr.GetOrdinal(field.ToUpper());
            if (pos >= 0 && pos < dr.FieldCount)
            {
                return dr.GetInt32(pos);
            }
            return (int?) null;
        }

        protected double? GetDouble(string field, IDataReader dr)
        {
            int pos = dr.GetOrdinal(field.ToUpper());
            if (pos >= 0 && pos < dr.FieldCount)
            {
                return dr.GetDouble(pos);
            }
            return (double?)null;
        }

        protected DateTime? GetDate(string field, IDataReader dr)
        {
            if (field == String.Empty)
                return (DateTime?)null;
            string data = this.GetString(field, dr);
            if(data.Length < 8)
                return (DateTime?)null;
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
                else if(field.Length == 14)
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
        #endregion
        protected abstract T FillModel(IDataReader dr);
        protected abstract void FillInsertParameters(IDbCommand cmd, T entity);

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

        public virtual void Insert(T entity)
        {
            if (entity == null)
                throw new ApplicationException("Insert Entity Null");
            var cmd = UnitOfWork.CreateCommand(StandardInsert);
            FillInsertParameters(cmd, entity);
            entity.Id = (long) cmd.ExecuteScalar();
        }

        public virtual ICollection<T> GetAll(string where)
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }

}
