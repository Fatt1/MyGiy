namespace Demo.Domain.Exceptions
{
    public class DuplicateSqlException : ConflictException
    {
        public DuplicateSqlException(string message) : base(message)
        {
        }
    }
}
