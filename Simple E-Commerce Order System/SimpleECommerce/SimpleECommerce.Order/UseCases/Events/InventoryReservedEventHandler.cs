using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleECommerce.Contracts.IntegrateEvents.InventoryEvents;
using SimpleECommerce.Inventory.Enums;
using SimpleECommerce.Order.Data;

namespace SimpleECommerce.Order.UseCases.Events
{
    public class InventoryReservedEventHandler : IRequestHandler<InventoryReservedEvent>
    {
        private readonly AppDbContext _context;
        public InventoryReservedEventHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task Handle(InventoryReservedEvent request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == request.OrderId);
            if (order != null && order.Status != OrderStatus.Canceled)
            {
                order.Status = OrderStatus.Confirmed;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
