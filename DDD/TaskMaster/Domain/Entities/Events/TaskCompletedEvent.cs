using Domain.Primitives;

namespace Domain.Entities.Events
{
    public record TaskCompletedEvent(Guid TaskId, Guid CompletedByUserId, DateTime CompletedAt) : IDomainEvent
    {
    }
}
