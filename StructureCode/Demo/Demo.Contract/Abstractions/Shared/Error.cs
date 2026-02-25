namespace Demo.Contract.Abstractions.Shared
{
    public class Error
    {

        public static readonly Error None = new(string.Empty, string.Empty);

        public Error(string message, string code)
        {
            Message = message;
            Code = code;
        }

        public static implicit operator string(Error error) => error.Code;

        public string Message { get; }
        public string Code { get; }

    }
}
