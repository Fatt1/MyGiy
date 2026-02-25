namespace Demo.Domain.Exceptions
{
    public class ForeignKeySqlException : BadRequestException
    {
        public ForeignKeySqlException(string message) : base(message)
        {
        }
    }
}
