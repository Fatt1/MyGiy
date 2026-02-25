using Masstransit.Contract.Abstractions.Messages;

namespace Masstransit.Contract.CommandBus
{
    public class SendEmailCommandBus : ISendEmailCommand
    {
        public Guid Id { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }


}
