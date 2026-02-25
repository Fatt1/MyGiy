
using Demo.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(e, context);

            }

        }

        private async Task HandleExceptionAsync(Exception exception, HttpContext httpContext)
        {
            var statusCode = GetStatusCode(exception);
            var title = GetTile(exception);
            var problemDetails = new ProblemDetails
            {
                Title = title,
                Status = statusCode,
                Detail = exception.Message,
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails);
        }

        private int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ConflictException => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

        private string GetTile(Exception exception) =>
            exception switch
            {
                DomainException applicationException => applicationException.Title,
                _ => "Server Error"
            };


    }
}
