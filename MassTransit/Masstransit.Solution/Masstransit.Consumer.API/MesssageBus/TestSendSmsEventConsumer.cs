using Masstransit.Consumer.API.Abstractions.Messages;
using Masstransit.Contract.Abstractions.IntegreationEvents;
using MediatR;

namespace Masstransit.Consumer.API.MesssageBus
{
    public class TestSendSmsEventConsumer : Consumer<DomainEvent.SmsNotifcationEvent>
    {
        public TestSendSmsEventConsumer(ISender sender) : base(sender)
        {
        }
    }
}
