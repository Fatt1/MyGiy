using MediatR;
using SimpleECommerce.Contracts.IntegrateEvents.OrderEvents;
using SimpleECommerce.Inventory.Abstractions;

namespace SimpleECommerce.Inventory.MessageBus
{
    public class OrderCancelledEventConsumer : Consumer<OrderCancelledEVent>
    {
        public OrderCancelledEventConsumer(ISender sender) : base(sender)
        {
        }
    }
}
