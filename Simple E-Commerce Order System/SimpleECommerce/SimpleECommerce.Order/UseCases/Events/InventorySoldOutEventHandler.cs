using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleECommerce.Contracts.IntegrateEvents.InventoryEvents;
using SimpleECommerce.Inventory.Enums;
using SimpleECommerce.Order.Data;

namespace SimpleECommerce.Order.UseCases.Events
{
    public class InventorySoldOutEventHandler : IRequestHandler<InventorySoldOutEvent>
    {
        private readonly AppDbContext _context;

        public InventorySoldOutEventHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(InventorySoldOutEvent request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == request.OrderId);
            if (order != null && order.Status != OrderStatus.Canceled)
            {
                order.Status = OrderStatus.Rejected;
                await _context.SaveChangesAsync(cancellationToken);
            }

        }
    }
}
