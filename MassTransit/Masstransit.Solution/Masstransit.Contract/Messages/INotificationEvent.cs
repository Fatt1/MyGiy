using MassTransit;

namespace Masstransit.Contract.Abstractions.Messages
{
    [ExcludeFromTopology]
    public interface INotificationEvent : IMessage
    {

    }
}
