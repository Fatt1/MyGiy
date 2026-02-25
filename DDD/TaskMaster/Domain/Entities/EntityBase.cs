using Domain.Abstract;

namespace Domain.Entities
{
    public abstract class EntityBase<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}
