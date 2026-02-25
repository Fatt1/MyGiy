namespace SimpleECommerce.Contracts.Abtractions.Entities
{
    public abstract class EntityBase<Tkey> : IEntity<Tkey>
    {
        public Tkey Id { get; set; }
    }
}
