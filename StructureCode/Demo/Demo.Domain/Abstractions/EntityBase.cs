using Demo.Domain.Abstractions.Entities;

namespace Demo.Domain.Abstractions
{
    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }

}
