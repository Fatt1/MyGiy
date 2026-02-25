namespace Demo.Contract.Abstractions.Shared
{
    public sealed class ValidationResult : Result, IValidationResult
    {
        private ValidationResult(Error[] errors)
            : base(IValidationResult.ValidationError, false)
        {
            Errors = errors;
        }

        public Error[] Errors { get; }

        public static ValidationResult WithErrors(Error[] errors) =>
            new ValidationResult(errors);
    }
}
