namespace Domain.Entities
{
    public class SubTask : EntityBase<Guid>
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public Guid TaskId { get; set; }

    }
}
