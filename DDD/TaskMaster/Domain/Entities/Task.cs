using Domain.Abstract;
using Domain.Constants;
using Domain.Entities.Events;

namespace Domain.Entities
{
    public class Task : AggreateRoot
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public TaskStatusEnum Status { get; private set; }
        public int Priority { get; private set; }
        public Guid ProjectId { get; private set; }
        public Guid? SprintId { get; private set; }
        public Guid? AssignUserId { get; private set; }

        private readonly List<SubTask> _subTasks = new();

        // Constructor for entity framework
        private Task()
        {

        }


        public IReadOnlyList<SubTask> SubTasks => _subTasks.AsReadOnly();

        public Task(string title, string description, TaskStatusEnum status, int priority, Guid projectId, Guid? assignUserId = null, Guid? spintId = null)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Status = status;
            Priority = priority;
            ProjectId = projectId;
            AssignUserId = assignUserId;
            SprintId = spintId;
        }

        public void AssignUser(Guid userId)
        {

            // 1. Kiểm tra logic (Invariant)
            if (Status == TaskStatusEnum.Done)
            {
                throw new InvalidOperationException("Không thể gán task đã hoàn thành!");
            }
            AssignUserId = userId;
            AddDomainEvent(new TaskAssignedEvent(Id, userId, Title, DateTime.UtcNow));
        }

        public void AddSprint(Guid sprintId)
        {
            SprintId = sprintId;
        }

        public void AddSubTask(SubTask subTask)
        {
            _subTasks.Add(subTask);
        }


        public void RemoveSubTask(SubTask subTask)
        {
            _subTasks.Remove(subTask);
        }

        public void CompleteSubTask(Guid subTaskId)
        {
            _subTasks.FirstOrDefault(st => st.Id == subTaskId).IsCompleted = true;
        }

        public void UpdateStatus(TaskStatusEnum status)
        {
            if (status == TaskStatusEnum.Done)
                if (_subTasks.Any(s => !s.IsCompleted))
                {
                    throw new InvalidOperationException("Cannot update status while there are incomplete subtasks.");
                }
            Status = status;
        }


    }
}
