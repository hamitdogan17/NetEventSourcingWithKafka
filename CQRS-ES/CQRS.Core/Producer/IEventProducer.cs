using CQRS.Core.Events;

namespace CQRS.Core.Producer
{
    public interface IEventProducer
    {
         Task ProduceAsync<T>(string topic, T @event) where T : BaseEvent;
    }
}