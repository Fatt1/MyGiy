using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleECommerce.Contracts.IntegrateEvents.InventoryEvents;
using SimpleECommerce.Inventory.Data;

namespace SimpleECommerce.Inventory.UseCases.Events
{
    public class ReleaseStockEventHandler : IRequestHandler<ReleaseStockEvent>
    {
        private readonly AppDbContext _context;
        public ReleaseStockEventHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ReleaseStockEvent request, CancellationToken cancellationToken)
        {
            var rowsAffected = await _context.Products
                .Where(p => p.Id == request.ProductId)
                .ExecuteUpdateAsync(s => s.SetProperty(p => p.StockQuantity, p => p.StockQuantity + request.Quantity));
        }
    }
}
