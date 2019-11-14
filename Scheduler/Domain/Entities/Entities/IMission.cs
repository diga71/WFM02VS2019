using Domain.UnitOfWork;
using System;
using System.Collections.Generic;

namespace Domain
{
    public interface IMission : IIdentity
    {
        string Description { get; set; }
        IActivity Activity { get; set; }
        long? IdAct { get; set; }
        DateTime? EndDate { get; }
        IOperator WFOperator { get; set; }
        long? IdOpe { get; set; }
        DateTime? StartDate { get; set; }
    }
}