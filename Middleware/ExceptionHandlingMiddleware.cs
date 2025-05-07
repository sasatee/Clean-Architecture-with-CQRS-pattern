using FluentValidation;
using System.Net;
using System.Text.Json;

namespace CleanArchitectureWithCQRSandMediator.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = new ErrorResponse();

            switch (exception)
            {
                case ValidationException validationEx:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Status = HttpStatusCode.BadRequest;
                    response.Message = "Validation failed";
                    response.Errors = validationEx.Errors
                        .GroupBy(x => x.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(x => x.ErrorMessage).ToArray()
                        );
                    break;

                case KeyNotFoundException notFoundEx:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Status = HttpStatusCode.NotFound;
                    response.Message = notFoundEx.Message;
                    break;

                default:
                    _logger.LogError(exception, "An unexpected error occurred");
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Status = HttpStatusCode.InternalServerError;
                    response.Message = "An unexpected error occurred";
                    break;
            }

            var result = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(result);
        }
    }

    public class ErrorResponse
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }
    }
} 