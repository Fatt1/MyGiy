using SimpleECommerce.Contracts.Abtractions.Messages;

namespace SimpleECommerce.Contracts.IntegrateEvents.OrderEvents
{
    public class OrderTimeoutCancelledEvent : IOrderEvent
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
