using System.Net;

namespace EventManagementSystemApi.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var response = new
                {
                    message = ex.Message,
                    statusCode = context.Response.StatusCode
                };
                await context.Response.WriteAsJsonAsync(response);
            }
            
        }
    }
}
