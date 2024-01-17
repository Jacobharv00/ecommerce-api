namespace EcommerceAPI.Middlewares
{
    public class StatsMiddleware
    {
        private readonly RequestDelegate _next;

        public StatsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            // Handle the request (Before executing the controller)
            DateTime requestTime = DateTime.Now;
            var result = _next(httpContext);

            // Handle the response (After executing the controller)
            DateTime responseTime = DateTime.Now;
            TimeSpan processDuration = responseTime - requestTime;

            Console.WriteLine("[Stats Middleware] Process Duration= " +
                processDuration.TotalMilliseconds + "ms");

            return result;
        }
    }

      // Extension method used to add the middleware to the HTTP request pipeline
        // public static class StatsMiddlewareExtensions
        // {
        //     public static IApplicationBuilder UseStatsMiddleware(this IApplicationBuilder builder)
        //     {
        //         return builder.UseMiddleware<StatsMiddleware>();
        //     }
        // }
}
