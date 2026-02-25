using MediatR;
using SimpleECommerce.Contracts.IntegrateEvents.InventoryEvents;
using SimpleECommerce.Order.Abstractions;

namespace SimpleECommerce.Order.MessageBus
{
    public class InventoryReservedEventConsumer : Consumer<InventoryReservedEvent>
    {
        public InventoryReservedEventConsumer(ISender sender) : base(sender)
        {
        }
    }
}
