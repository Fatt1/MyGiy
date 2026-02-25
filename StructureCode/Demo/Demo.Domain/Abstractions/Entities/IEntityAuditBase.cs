namespace Demo.Domain.Abstractions.Entities
{
    public interface IEntityAuditBase<TKey> : IEntity<TKey>, IAuditable
    {
    }
}
