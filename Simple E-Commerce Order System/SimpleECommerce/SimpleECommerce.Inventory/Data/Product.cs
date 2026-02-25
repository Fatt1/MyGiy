using SimpleECommerce.Contracts.Abtractions.Entities;

namespace SimpleECommerce.Inventory.Data
{
    public class Product : EntityBase<Guid>
    {
        public string Name { get; set; }
        public int StockQuantity { get; set; }
    }
}
