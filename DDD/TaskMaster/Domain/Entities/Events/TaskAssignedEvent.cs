using Domain.Primitives;

namespace Domain.Entities.Events
{
    public record TaskAssignedEvent(Guid TaskId, Guid AssigneeId, string Title, DateTime AssignedAt) : IDomainEvent
    {
    }
}
