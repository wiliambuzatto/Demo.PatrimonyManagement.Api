using Demo.PatrimonyManagement.Domain.Common;
using Demo.PatrimonyManagement.Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Demo.GestaoPatrimonio.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (PatrimonyManagementException ex)
            {
                var result = new Result();
                result.Messages.Add(ex.Message);
                var jsonResponse = JsonConvert.SerializeObject(result);

                httpContext.Response.Clear();
                httpContext.Response.StatusCode = (int)ex.ErrorType;
                await httpContext.Response.WriteAsync(jsonResponse);
                return;
            }
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder) => builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
