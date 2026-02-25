using Demo.Contract.Abstractions.Messages;

namespace Demo.Contract.Services.V1.Products
{
    public static class Command
    {
        public record CreateProductCommand : ICommand<int>
        {
            public string Name { get; set; } = null!;
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
        }
    }
}
