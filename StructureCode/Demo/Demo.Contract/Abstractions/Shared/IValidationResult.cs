namespace Demo.Contract.Abstractions.Shared
{
    public interface IValidationResult
    {
        public static Error ValidationError = new(
            "ValidationError", "A validation problem occurred.");

        Error[] Errors { get; }
    }
}
