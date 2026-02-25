using MediatR;
using SimpleECommerce.Contracts.IntegrateEvents.InventoryEvents;
using SimpleECommerce.Order.Abstractions;

namespace SimpleECommerce.Order.MessageBus
{
    public class InventorySoldOutEventConsumer : Consumer<InventorySoldOutEvent>
    {
        public InventorySoldOutEventConsumer(ISender sender) : base(sender)
        {
        }
    }
}
