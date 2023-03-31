using KredoBank.API.Middleware.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace KredoBank.API.Middleware
{
    public class GlobalMiddleware
    {
        private readonly RequestDelegate next;
        private string requestBody;
        public GlobalMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                httpContext.Request.EnableBuffering();
                using (var reader = new StreamReader(httpContext.Request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, bufferSize: 1024, leaveOpen: true))
                {
                    string requestBody = await reader.ReadToEndAsync();
                    httpContext.Request.Body.Position = 0;
                }

                Log.Information("Custom middleware");
                await next(httpContext);
            }
            catch (System.Exception ex)
            {
                ExceptionModel exceptionModel = new ExceptionModel();
                exceptionModel.HttpMethod = httpContext.Request.Method;
                exceptionModel.QueryStringValue = httpContext.Request.QueryString.Value;
                exceptionModel.RequestBody = requestBody;
                exceptionModel.ExceptionMessage = ex.Message;
                exceptionModel.ExceptionStackSTrace = ex.StackTrace;
                exceptionModel.InnerExceptionMessage = ex.InnerException?.Message;
                exceptionModel.InnerExceptionStackTrace = ex.InnerException?.StackTrace;

                Log.Error("Exception in Application. " + JsonConvert.SerializeObject(exceptionModel));
            }
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalMiddleware>();
        }
    }
}
