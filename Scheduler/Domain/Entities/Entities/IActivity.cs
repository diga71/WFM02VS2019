
using Domain.UnitOfWork;

namespace Domain
{
    public interface IActivity : IIdentity
    {
        string Description { get; set; }
        double? Effort { get; set; }
    }
}