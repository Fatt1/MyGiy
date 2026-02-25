using MediatR;

namespace SimpleECommerce.Order.Models
{
    public record CreateOrderDTO : IRequest<Guid>
    {
        public Guid CustomerId { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }
        public Guid ProductId { get; init; }

    }
}
