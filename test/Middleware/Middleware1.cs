using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace test.Middleware
{
    public class Middleware1
    {
        private readonly RequestDelegate _next;

        public Middleware1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Логирование информации о запросе
            var path_Request = context.Request.Path;
            var path_Response = context.Response.StatusCode; 
            var method = context.Request.Method;
            Console.WriteLine($"Received {method} request to {path_Request}");
            Console.WriteLine($"Method {path_Response}");
            await _next(context);
        }
    }
    public static class Middleware1Extensions
    {
        public static IApplicationBuilder UseMiddleware1(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware1>();
        }
    }
}
