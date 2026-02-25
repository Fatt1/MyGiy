using SimpleECommerce.Contracts.Abtractions.Messages;

namespace SimpleECommerce.Contracts.IntegrateEvents.InventoryEvents
{
    // InventoryService gửi đi khi kho không đủ hàng.
    public class InventorySoldOutEvent : IInventoryEvent
    {
        public Guid Id { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public Guid OrderId { get; set; }
        public string Reason { get; set; }
    }
}
