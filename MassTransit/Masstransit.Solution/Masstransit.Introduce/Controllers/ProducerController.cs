using Masstransit.Contract.Abstractions.Constants;
using Masstransit.Contract.Abstractions.IntegreationEvents;
using Masstransit.Contract.CommandBus;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Masstransit.Introduce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IBus _bus;

        public ProducerController(IPublishEndpoint publishEndpoint, IBus bus)
        {
            _publishEndpoint = publishEndpoint;
            _bus = bus;
        }

        [HttpPost("publish-sms-notifaction")]
        public async Task<IActionResult> PublishSmsNotifactionEvent()
        {
            await _publishEndpoint.Publish(new DomainEvent.SmsNotifcationEvent
            {
                Id = Guid.NewGuid(),
                Description = "Sms Description",
                TimeStamp = DateTime.Now,
                TransactionId = Guid.NewGuid(),
                Type = NotificationType.sms
            });
            return Accepted();
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmailEvent()
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:send-email-command-queue"));
            await endpoint.Send(new SendEmailCommandBus
            {
                Id = Guid.NewGuid(),
                TimeStamp = DateTimeOffset.Now,
                To = "Fat",
                Body = "AHiahi dodof ngoc",
                Subject = "Test email",
                From = "test123@gmail.com"
            });
            return Accepted();
        }
    }
}
