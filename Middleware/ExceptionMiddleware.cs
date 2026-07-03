using BankManagementSystem.Exceptions;
using System.Net;
using System.Text.Json;

namespace BankManagementSystem.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            int statusCode;
            string message;

            switch (exception)
            {
                case AccountNotFoundEXception:
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;

                case InsufficientBalanceException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;

                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    message = "An unexpected error occurred.";
                    break;
            }

            context.Response.StatusCode = statusCode;

            var response = new
            {
                StatusCode = statusCode,
                Message = message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
