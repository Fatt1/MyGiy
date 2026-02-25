using Domain.Entities;
using Domain.Primitives;

namespace Domain.Abstract
{
    public abstract class AggreateRoot : EntityBase<Guid>
    {
        private readonly List<IDomainEvent> _domainEvent = new();

        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvent.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvent.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvent.Clear();
        }
    }
}
