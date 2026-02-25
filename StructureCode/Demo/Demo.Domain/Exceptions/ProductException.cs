namespace Demo.Domain.Exceptions
{
    public static class ProductException
    {
        public class ProductNotFoundException : NotFoundException
        {
            public ProductNotFoundException(Guid productId)
                : base($"Product with ID '{productId}' was not found.")
            {
            }
        }
    }
}
