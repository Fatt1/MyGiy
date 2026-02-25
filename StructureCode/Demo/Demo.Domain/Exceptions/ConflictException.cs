namespace Demo.Domain.Exceptions
{
    public abstract class ConflictException : DomainException
    {
        protected ConflictException(string message) : base("Conflict", message)
        {
        }
    }
}
