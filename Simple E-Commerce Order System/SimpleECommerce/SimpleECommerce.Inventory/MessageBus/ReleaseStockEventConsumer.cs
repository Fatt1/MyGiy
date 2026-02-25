using MediatR;
using SimpleECommerce.Contracts.IntegrateEvents.InventoryEvents;
using SimpleECommerce.Inventory.Abstractions;

namespace SimpleECommerce.Inventory.MessageBus
{
    public class ReleaseStockEventConsumer : Consumer<ReleaseStockEvent>
    {
        public ReleaseStockEventConsumer(ISender sender) : base(sender)
        {
        }

    }
}
