using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleECommerce.Contracts.IntegrateEvents.OrderEvents;
using SimpleECommerce.Inventory.Data;

namespace SimpleECommerce.Inventory.UseCases.Events
{
    public class OrderCancelledEventHandler : IRequestHandler<OrderCancelledEVent>
    {
        private readonly AppDbContext _context;

        public OrderCancelledEventHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(OrderCancelledEVent request, CancellationToken cancellationToken)
        {
            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var rowsAffected = await _context.Products
                    .Where(p => p.Id == request.ProductId)
                    .ExecuteUpdateAsync(s => s.SetProperty(p => p.StockQuantity, p => p.StockQuantity + request.Quantity), cancellationToken);


                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }

        }
    }
}
