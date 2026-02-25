using Masstransit.Contract.Abstractions.IntegreationEvents;
using MediatR;

namespace Masstransit.Consumer.API.Usecases.Events
{
    public class SendSmsEventConsumerHandler : IRequestHandler<DomainEvent.SmsNotifcationEvent>
    {
        private readonly ILogger<SendSmsEventConsumerHandler> _logger;
        public SendSmsEventConsumerHandler(ILogger<SendSmsEventConsumerHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(DomainEvent.SmsNotifcationEvent request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Message received: {message}", request);
            await Task.CompletedTask;
        }
    }
}
