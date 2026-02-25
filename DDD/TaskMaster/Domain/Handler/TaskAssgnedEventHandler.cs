using Domain.Entities.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Domain.Handler
{
    public class TaskAssgnedEventHandler : INotificationHandler<TaskAssignedEvent>
    {
        private readonly ILogger<TaskAssgnedEventHandler> _logger;
        public TaskAssgnedEventHandler(ILogger<TaskAssgnedEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(TaskAssignedEvent notification, CancellationToken cancellationToken)
        {
            // 2. Dùng Logger thay vì Console
            _logger.LogInformation("🚀 [DOMAIN EVENT] Task '{Title}' ({Id}) đã giao cho User {UserId} lúc {Time}",
                notification.Title,
                notification.TaskId,
                notification.AssigneeId,
                notification.AssignedAt);

            // Nếu muốn lưu DB:
            // var history = new TaskHistory(notification.TaskId, notification.NewAssigneeId);
            // await _historyRepo.AddAsync(history);

            return Task.CompletedTask;
        }
    }
}
