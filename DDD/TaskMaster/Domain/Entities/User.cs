namespace Domain.Entities
{
    public class User : EntityBase<Guid>
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}
