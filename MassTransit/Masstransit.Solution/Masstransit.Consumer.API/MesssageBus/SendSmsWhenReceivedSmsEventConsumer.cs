using Masstransit.Consumer.API.Abstractions.Messages;
using Masstransit.Contract.Abstractions.IntegreationEvents;
using MediatR;

namespace Masstransit.Consumer.API.MesssageBus
{

    public class SendSmsWhenReceivedSmsEventConsumer : Consumer<DomainEvent.SmsNotifcationEvent>
    {
        public SendSmsWhenReceivedSmsEventConsumer(ISender sender) : base(sender)
        {
        }
    }
}
