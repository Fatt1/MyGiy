using Demo.Domain.Abstractions;

namespace Demo.Domain.Entities
{
    public class Category : EntityAuditBase<int>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        // Navigation properties
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
