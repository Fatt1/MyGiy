using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleECommerce.Contracts.IntegrateEvents.OrderEvents;
using SimpleECommerce.Inventory.Enums;
using SimpleECommerce.Order.Data;

namespace SimpleECommerce.Order.UseCases.Commands.Orders
{
    public record CancelOrderCommand : IRequest
    {
        public Guid OrderId { get; init; }
    }

    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly AppDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public CancelOrderCommandHandler(AppDbContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }
        public async Task Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);
            if (order != null)
            {
                order.Status = OrderStatus.Canceled;

                await _publishEndpoint.Publish(new OrderCancelledEVent
                {
                    Id = Guid.NewGuid(),
                    ProductId = order.ProductId,
                    Quantity = order.Quantity,
                    TimeStamp = DateTimeOffset.UtcNow
                }, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);
                return;
            }
            throw new Exception("Order not found");
        }
    }
}
