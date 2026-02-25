using SimpleECommerce.Contracts.Abtractions.Entities;
using SimpleECommerce.Inventory.Enums;

namespace SimpleECommerce.Order.Data
{
    public class Order : EntityBase<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
