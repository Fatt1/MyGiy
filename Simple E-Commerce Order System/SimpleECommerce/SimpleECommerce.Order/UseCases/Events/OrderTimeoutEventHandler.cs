using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleECommerce.Contracts.IntegrateEvents.InventoryEvents;
using SimpleECommerce.Contracts.IntegrateEvents.OrderEvents;
using SimpleECommerce.Order.Data;

namespace SimpleECommerce.Order.UseCases.Events
{
    public class OrderTimeoutEventHandler : IRequestHandler<OrderTimeoutEvent>
    {
        private readonly AppDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<OrderTimeoutEventHandler> _logger;
        public OrderTimeoutEventHandler(AppDbContext context, ILogger<OrderTimeoutEventHandler> logger, IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            _context = context;
            _logger = logger;
        }
        public async Task Handle(OrderTimeoutEvent request, CancellationToken cancellationToken)
        {
            var rowAffected = await _context.Orders
                .Where(o => o.Id == request.OrderId && o.Status == Inventory.Enums.OrderStatus.Received)
                .ExecuteUpdateAsync(s => s.SetProperty(o => o.Status, Inventory.Enums.OrderStatus.Failed));

            if (rowAffected > 0)
            {
                var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == request.OrderId);
                _logger.LogInformation("Order {OrderId} has been marked as Failed due to checkout timeout.", request.OrderId);
                await _publishEndpoint.Publish(new ReleaseStockEvent
                {
                    Id = Guid.NewGuid(),
                    TimeStamp = DateTimeOffset.UtcNow,
                    ProductId = order!.ProductId,
                    Quantity = order.Quantity
                });
            }

            else
            {
                _logger.LogInformation("Order was already processed. Timeout ignored");
            }

        }
    }
}
