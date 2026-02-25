using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleECommerce.Contracts.IntegrateEvents.InventoryEvents;
using SimpleECommerce.Contracts.IntegrateEvents.OrderEvents;
using SimpleECommerce.Inventory.Data;

namespace SimpleECommerce.Inventory.UseCases.Events
{
    public class OrderCreatedEventHandler : IRequestHandler<OrderCreatedEvent>
    {
        private readonly AppDbContext _dbContext;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderCreatedEventHandler(AppDbContext dbContext, IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            _dbContext = dbContext;
        }
        public async Task Handle(OrderCreatedEvent request, CancellationToken cancellationToken)
        {

            using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var rowsAffected = await _dbContext.Products
              .Where(p => p.Id == request.ProductId && p.StockQuantity >= request.Quantity)
              .ExecuteUpdateAsync(s => s.SetProperty(p => p.StockQuantity, p => p.StockQuantity - request.Quantity), cancellationToken);

                if (rowsAffected > 0)
                {
                    // Trừ thành công (DB trả về 1 dòng được update)
                    await _publishEndpoint.Publish(new InventoryReservedEvent
                    {
                        OrderId = request.OrderId,
                        Id = Guid.NewGuid(),
                        TimeStamp = DateTimeOffset.UtcNow

                    }, cancellationToken);

                }
                else
                {
                    // Không tìm thấy sản phẩm HOẶC Tồn kho không đủ (nhờ điều kiện Where ở trên)
                    await _publishEndpoint.Publish(new InventorySoldOutEvent
                    {
                        OrderId = request.OrderId,
                        Id = Guid.NewGuid(),
                        TimeStamp = DateTimeOffset.UtcNow
                    }, cancellationToken);


                }
                await _dbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
            }




        }
    }
}
