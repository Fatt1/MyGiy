using Demo.Domain.Abstractions;
using Demo.Domain.Abstractions.Entities;

namespace Demo.Domain.Entities
{
    public class Product : EntityAuditBase<int>, ISoftDelete
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }

        // Navigation property
        public Category Category { get; set; } = null!;
    }
}
