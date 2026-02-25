using Demo.Domain.Abstractions.Entities;

namespace Demo.Domain.Abstractions
{
    public abstract class EntityAuditBase<TKey> : IEntityAuditBase<TKey>
    {
        public TKey Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
