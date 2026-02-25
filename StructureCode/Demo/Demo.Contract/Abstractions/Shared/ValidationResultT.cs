namespace Demo.Contract.Abstractions.Shared
{
    public class ValidationResult<TValue> : Result<TValue>, IValidationResult
    {
        private ValidationResult(Error[] errors)
            : base(IValidationResult.ValidationError, false, default) => Errors = errors;

        public Error[] Errors { get; }

        public static ValidationResult<TValue> WithErrors(Error[] errors) =>
            new(errors);
    }
}
