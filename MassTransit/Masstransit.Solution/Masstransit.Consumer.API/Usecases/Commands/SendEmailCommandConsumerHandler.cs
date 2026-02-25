using Masstransit.Contract.CommandBus;
using MediatR;

namespace Masstransit.Consumer.API.Usecases.Commands
{
    public class SendEmailCommandConsumerHandler : IRequestHandler<SendEmailCommandBus>
    {
        private readonly ILogger<SendEmailCommandConsumerHandler> _logger;
        public SendEmailCommandConsumerHandler(ILogger<SendEmailCommandConsumerHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(SendEmailCommandBus request, CancellationToken cancellationToken)
        {
            // Simulate sending email
            _logger.LogInformation("Sending email to {To} with subject {Subject}", request.To, request.Subject);
            return Task.CompletedTask;
        }
    }
}
