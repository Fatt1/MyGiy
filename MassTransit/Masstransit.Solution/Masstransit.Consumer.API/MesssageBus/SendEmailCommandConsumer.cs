using Masstransit.Consumer.API.Abstractions.Messages;
using Masstransit.Contract.CommandBus;
using MassTransit;
using MediatR;

namespace Masstransit.Consumer.API.MesssageBus
{

    public class SendEmailCommandConsumer : Consumer<SendEmailCommandBus>
    {
        public SendEmailCommandConsumer(ISender sender) : base(sender)
        {
        }
    }

    public class SendEmailCommandConsumerDefinition : ConsumerDefinition<SendEmailCommandConsumer>
    {
        public SendEmailCommandConsumerDefinition()
        {
            EndpointName = "send-email-command-queue";
        }


        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<SendEmailCommandConsumer> consumerConfigurator, IRegistrationContext context)
        {
            endpointConfigurator.ConfigureConsumeTopology = false;

        }
    }
}
