using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using X.Domain.Shared;

namespace X.Infrastructure.Middlewares
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var traceId = Guid.NewGuid().ToString();
            _logger.LogError($"Error occure while processing the request, TraceId : ${traceId},  Message : ${ex.Message}, StackTrace: ${ex.StackTrace}");

            var response = context.Response;
            response.ContentType = "application/json";
            var error = new ErrorResult();

            error.StatusCode = ex switch
            {
                ApplicationException => (int)HttpStatusCode.BadRequest,
                ArgumentNullException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            error.Message = ex.Message;
            error.TraceId = traceId;
            error.StackTrace = ex.StackTrace;

            var exJson = JsonSerializer.Serialize(error);
            await response.WriteAsync(exJson);
        }
    }
}
