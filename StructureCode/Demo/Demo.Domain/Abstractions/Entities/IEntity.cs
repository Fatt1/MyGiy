namespace Demo.Domain.Abstractions.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
