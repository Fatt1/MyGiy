using MassTransit;
using MediatR;
using SimpleECommerce.Contracts.IntegrateEvents.OrderEvents;
using SimpleECommerce.Inventory.Enums;
using SimpleECommerce.Order.Data;

namespace SimpleECommerce.Order.UseCases.Commands.Orders
{
    public record CreateOrderCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }
        public Guid ProductId { get; init; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMessageScheduler _messageScheduler;
        private readonly AppDbContext _context;
        public CreateOrderCommandHandler(IPublishEndpoint publishEndpoint, AppDbContext context, IMessageScheduler messageScheduler)
        {
            _publishEndpoint = publishEndpoint;
            _context = context;
            _messageScheduler = messageScheduler;
        }
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order.Data.Order
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                CustomerId = request.CustomerId,
                Price = request.Price,
                Quantity = request.Quantity,
                CreatedAt = DateTime.UtcNow,
                Status = OrderStatus.Received,
            };
            _context.Orders.Add(order);


            await _publishEndpoint.Publish(new OrderCreatedEvent
            {
                Id = Guid.NewGuid(),
                TimeStamp = DateTimeOffset.UtcNow,
                OrderId = order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
            }, cancellationToken);


            await _messageScheduler.SchedulePublish(DateTime.UtcNow.AddSeconds(30), new OrderTimeoutEvent
            {
                Id = Guid.NewGuid(),
                TimeStamp = DateTimeOffset.UtcNow,
                OrderId = order.Id,
            });

            await _context.SaveChangesAsync();


            return order.Id;
        }
    }
}
