namespace SimpleECommerce.Contracts.Abtractions.Entities
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
