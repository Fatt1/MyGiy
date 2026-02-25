using Demo.Contract.Abstractions.Shared;
using FluentValidation;
using MediatR;

namespace Demo.Application.Behaviors
{
    public sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
        where TResponse : Result
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            Error[] errors = _validators
                .Select(v => v.Validate(request))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure != null)
                .Select(failure => new Error(
                    failure.PropertyName,
                    failure.ErrorMessage
                    ))
                .Distinct()
                .ToArray();

            if (errors.Any())
            {
                return CreateValidationResult<TResponse>(errors);
            }
            return await next();
        }


        private TResult CreateValidationResult<TResult>(Error[] errors) where TResult : Result
        {
            // Kiểm tra nếu TResult ở handler là Result
            if (typeof(TResult) == typeof(Result))
            {
                return (ValidationResult.WithErrors(errors) as TResult)!;
            }


            // Tạo validation result theo generic type của TResult
            // Sử dụng kỹ thuật reflection để tạo instance của ValidationResult<T>
            object validationResult = typeof(ValidationResult<>) // Lấy ra Type của ValidationResult<>
                .GetGenericTypeDefinition() // Nó sẽ trả về ValidationResult<>, chưa có type cụ thể
                .MakeGenericType(typeof(TResult).GetGenericArguments()) // Tạo ra ValidationResult<GenericTypeResult>

                // Ví dụ: IRequest<Result<int>> thì GenericTypeResult sẽ là int, kết quả là ValidationResult<int>
                .GetMethod(nameof(ValidationResult.WithErrors))!
                .Invoke(null, new object?[] { errors })!;

            return (TResult)validationResult;
        }
    }
}
