using MediatR;
using SimpleECommerce.Contracts.IntegrateEvents.OrderEvents;
using SimpleECommerce.Order.Abstractions;

namespace SimpleECommerce.Order.MessageBus
{
    public class OrderTimeoutEventConsumer : Consumer<OrderTimeoutEvent>
    {
        public OrderTimeoutEventConsumer(ISender sender) : base(sender)
        {
        }
    }
}
