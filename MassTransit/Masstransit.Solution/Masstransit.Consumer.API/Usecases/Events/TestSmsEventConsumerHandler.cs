using Masstransit.Contract.Abstractions.IntegreationEvents;
using MediatR;

namespace Masstransit.Consumer.API.Usecases.Events
{
    public class TestSmsEventConsumerHandler : IRequestHandler<DomainEvent.SmsNotifcationEvent>
    {
        private readonly ILogger<TestSmsEventConsumerHandler> _logger;
        public TestSmsEventConsumerHandler(ILogger<TestSmsEventConsumerHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(DomainEvent.SmsNotifcationEvent request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received SMS Notification Event: {Name}, Description: {Description}, Type: {Type}, TransactionId: {TransactionId}, Id: {Id}, TimeStamp: {TimeStamp}",
                request.Name, request.Description, request.Type, request.TransactionId, request.Id, request.TimeStamp);
            // Simulate processing the SMS notification event
            return Task.CompletedTask;
        }
    }
}
