using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service
{
    interface IService
    {
        IUnitOfWork UnitOfWork { get; }
    }

    public abstract class AbstractService : IService
    {
        public AbstractService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork
        {
            get;
            private set;
        }
    }
}
