using MediatR;
using SimpleECommerce.Contracts.IntegrateEvents.OrderEvents;
using SimpleECommerce.Inventory.Abstractions;

namespace SimpleECommerce.Inventory.MessageBus
{
    public class OrderCreatedEventConsumer : Consumer<OrderCreatedEvent>
    {
        public OrderCreatedEventConsumer(ISender sender) : base(sender)
        {
        }
    }
}
