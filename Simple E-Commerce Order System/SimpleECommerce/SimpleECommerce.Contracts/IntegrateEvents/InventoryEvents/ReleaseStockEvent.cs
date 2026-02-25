using SimpleECommerce.Contracts.Abtractions.Messages;

namespace SimpleECommerce.Contracts.IntegrateEvents.InventoryEvents
{
    public class ReleaseStockEvent : IInventoryEvent
    {
        public Guid ProductId { get; set; }
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
