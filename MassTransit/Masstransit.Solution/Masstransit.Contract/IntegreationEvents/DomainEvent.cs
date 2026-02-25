using Masstransit.Contract.Abstractions.Messages;
using MassTransit;

namespace Masstransit.Contract.Abstractions.IntegreationEvents
{
    public static class DomainEvent
    {

        public record EmailNotifcationEvent : INotificationEvent
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; } // Sms | Email
            public Guid TransactionId { get; set; }
            public Guid Id { get; set; }
            public DateTimeOffset TimeStamp { get; set; }
        }

        [EntityName("sms-notification-event")]
        public record SmsNotifcationEvent : INotificationEvent
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; } // Sms | Email
            public Guid TransactionId { get; set; }
            public Guid Id { get; set; }
            public DateTimeOffset TimeStamp { get; set; }
        }
    }
}
