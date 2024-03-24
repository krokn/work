namespace test.Middleware
{
    public class Middleware2
    {
        private readonly RequestDelegate _next;

        public Middleware2(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Логирование информации о запросе
            var some_request = context.Request.Host.ToString();
            var some_response = context.Response.Body.ToString();
            Console.WriteLine($"Host from request {some_request} ");
            Console.WriteLine($"Body from response {some_response}");
            await _next(context);
        }
    }
    public static class Middleware2Extensions
    {
        public static IApplicationBuilder Middleware2(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware2>();
        }
    }
}
