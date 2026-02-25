using Masstransit.Contract.Abstractions.Messages;
using MassTransit;
using MediatR;

namespace Masstransit.Consumer.API.Abstractions.Messages
{
    public abstract class Consumer<TMessage> : IConsumer<TMessage> where TMessage : class, IMessage
    {
        private readonly ISender _sender;
        public Consumer(ISender sender)
        {
            _sender = sender;
        }
        public async Task Consume(ConsumeContext<TMessage> context)
        {
            await _sender.Send(context.Message);

        }
    }
}
