using Newtonsoft.Json;
using PT.DockerWebAPI.Model;
using System.Net;

namespace PT.DockerWebAPI.Helpers
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ErrorMessage errorObj = new ErrorMessage()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = exception.Message
            };

            if (exception is BadHttpRequestException)
            {
                BadHttpRequestException serviceException = (BadHttpRequestException)exception;
                errorObj.StatusCode = (HttpStatusCode)serviceException.StatusCode;
                errorObj.Message = serviceException.Message;
            }

            var result = JsonConvert.SerializeObject(errorObj);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorObj.StatusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
