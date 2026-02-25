using SimpleECommerce.Contracts.Abtractions.Messages;

namespace SimpleECommerce.Contracts.IntegrateEvents.InventoryEvents
{
    // InventoryService gửi đi khi trừ kho thành công.
    public class InventoryReservedEvent : IInventoryEvent
    {
        public Guid Id { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public Guid OrderId { get; set; }
    }
}
