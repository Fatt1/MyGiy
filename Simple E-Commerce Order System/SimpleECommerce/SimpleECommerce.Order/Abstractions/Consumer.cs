using MassTransit;
using MediatR;
using SimpleECommerce.Contracts.Abtractions.Messages;

namespace SimpleECommerce.Order.Abstractions
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
