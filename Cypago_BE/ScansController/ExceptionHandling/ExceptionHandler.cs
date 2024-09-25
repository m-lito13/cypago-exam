using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CypagoApp.ExceptionHandling
{
    public class ExceptionHandler
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;
        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;

            ErrorResponse errorResponse = new ErrorResponse();
            errorResponse.Details = exception.Message;
            switch (exception)
            {
                case InvalidDataException:
                case ArgumentException:
                case FormatException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Message = "Bad input data";
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case DbUpdateException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Message = "Cannot update data in DB";
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Message = "Internal server error";
                    errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            _logger.LogError(exception.StackTrace);
            var result = errorResponse.ToString();
            await context.Response.WriteAsync(result);
        }

    }
}
