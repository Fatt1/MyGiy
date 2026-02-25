using MassTransit;
using MediatR;

namespace SimpleECommerce.Contracts.Abtractions.Messages
{
    [ExcludeFromTopology]
    public interface IMessage : IRequest
    {
        public Guid Id { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

    }
}
