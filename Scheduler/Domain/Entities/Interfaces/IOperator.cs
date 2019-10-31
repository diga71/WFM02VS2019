using Domain.UnitOfWork;

namespace Domain
{
    public interface IOperator : IIdentity
    {
        string EMail { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string GetSummary();
    }
}