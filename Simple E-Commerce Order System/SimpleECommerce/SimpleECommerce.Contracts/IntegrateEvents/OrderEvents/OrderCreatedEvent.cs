using SimpleECommerce.Contracts.Abtractions.Messages;

namespace SimpleECommerce.Contracts.IntegrateEvents.OrderEvents
{
    public class OrderCreatedEvent : IOrderEvent
    {
        public Guid Id { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
