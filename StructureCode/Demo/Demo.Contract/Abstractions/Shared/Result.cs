namespace Demo.Contract.Abstractions.Shared
{
    public class Result
    {
        public Error? Error { get; }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;


        protected Result(Error error, bool isSuccess)
        {
            if (isSuccess && error != null)
            {
                throw new InvalidOperationException("Invalid Error");
            }
            if (!isSuccess && error == null)
            {
                throw new InvalidOperationException("Invalid Error");
            }

            Error = error;
            IsSuccess = isSuccess;
        }

        public static Result Failure(Error error) => new Result(error, false);
        public static Result Success() => new Result(Error.None, true);
    }

    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        public TValue? Value => IsSuccess
            ? _value
            : throw new InvalidOperationException("The value of a failure can not be accessed");

        protected internal Result(Error error, bool isSuccess, TValue? value) : base(error, isSuccess)
        {
            _value = value;
        }

        public static Result<TValue> Success(TValue value) =>
            new(Error.None, true, value);

        public static new Result<TValue> Failure(Error error) =>
            new(error, false, default);

    }
}
