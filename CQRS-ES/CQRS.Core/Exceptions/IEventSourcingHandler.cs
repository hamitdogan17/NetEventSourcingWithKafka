using CQRS.Core.Domain;

namespace CQRS.Core.Exceptions
{
    public interface IEventSourcingHandler<T>
    {
        Task SaveAsync(AggregateRoot aggregate);
        Task<T> GetByIdAsync(Guid aggregateId);        
    }
}