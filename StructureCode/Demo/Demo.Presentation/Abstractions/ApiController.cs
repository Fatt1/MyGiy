using Demo.Contract.Abstractions.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Abstractions
{
    public class ApiController : ControllerBase
    {
        protected readonly ISender _sender;

        public ApiController(ISender sender)
        {
            _sender = sender;
        }

        protected IActionResult HandleFaiure(Result result) =>
            result switch
            {
                { IsSuccess: true } => throw new InvalidOperationException(),
                IValidationResult validationResult => BadRequest(
                    CreateProblemDetails(
                        "Validation Error", StatusCodes.Status400BadRequest,
                        result.Error,
                        validationResult.Errors
                    )),
                _ => BadRequest(
                    CreateProblemDetails(
                        "Bad Request",
                        StatusCodes.Status400BadRequest,
                        result.Error)
                    )

            };

        private static ProblemDetails CreateProblemDetails(
            string title,
            int status,
            Error error,
            Error[]? errors = null) =>
            new()
            {
                Title = title,
                Type = error.Code,
                Status = status,
                Detail = error.Message,
                Extensions = { { nameof(errors), errors } }
            };

    }
}
