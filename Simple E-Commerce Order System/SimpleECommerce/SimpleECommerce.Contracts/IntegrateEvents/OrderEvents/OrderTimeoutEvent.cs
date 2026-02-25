using SimpleECommerce.Contracts.Abtractions.Messages;

namespace SimpleECommerce.Contracts.IntegrateEvents.OrderEvents
{
    public class OrderTimeoutEvent : IOrderEvent
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
