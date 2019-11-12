using Domain.UnitOfWork;
using System;
using System.Collections.Generic;

namespace Domain
{
    public interface IMission : IIdentity
    {
        string Description { get; set; }
        IActivity Activity { get; set; }
        DateTime? EndDate { get; }
        IOperator Operator { get; set; }
        DateTime? StartDate { get; set; }
    }
}