using Domain.Abstract;

namespace Domain.Entities
{
    public class Project : AggreateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }

    }
}
