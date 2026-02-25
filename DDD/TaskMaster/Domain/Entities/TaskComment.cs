using Domain.Abstract;

namespace Domain.Entities
{
    public class TaskComment : AggreateRoot
    {
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid TaskId { get; private set; }

        public Guid UserId { get; private set; }
        public string UserFullName { get; private set; }

        // Constructor for entity framework
        public TaskComment()
        {
        }

        public TaskComment(string content, Guid userId, DateTime createdAt, Guid taskId, string userFullName)
        {
            Content = content;
            UserId = userId;
            CreatedAt = createdAt;
            TaskId = taskId;
            UserFullName = userFullName;
        }
    }
}
