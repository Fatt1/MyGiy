using SimpleECommerce.Contracts.Abtractions.Messages;

namespace SimpleECommerce.Contracts.IntegrateEvents.OrderEvents
{
    public class OrderCancelledEVent : IOrderEvent
    {
        public Guid ProductId { get; set; }
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
